using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Views;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AddressService addressService, IWebHostEnvironment hostingEnvironment) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
    private readonly AddressService _addressService = addressService;

    #region Details
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };

        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion

    #region HttpPost Details
    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfo != null)
        {
            if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo!.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.Email;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.Bio = viewModel.BasicInfo.Biography;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                        ViewData["ErrorMessage"] = "Something went wrong! Unable to update basic information.";
                    }
                }
            }
        }

        if (viewModel.AddressInfo != null)
        {
            if (viewModel.AddressInfo.AddressLine_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var address = await _addressService.GetAddressAsync(user.Id);
                    if (address != null)
                    {
                        address.AddressLine_1 = viewModel.AddressInfo!.AddressLine_1;
                        address.AddressLine_2 = viewModel.AddressInfo.AddressLine_2;
                        address.PostalCode = viewModel.AddressInfo.PostalCode;
                        address.City = viewModel.AddressInfo.City;

                        var result = await _addressService.UpdateAddressAsync(address);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                            ViewData["ErrorMessage"] = "Something went wrong! Unable to update address information";
                        }
                    }
                    else
                    {
                        address = new AddressEntity
                        {
                            UserId = user.Id,
                            AddressLine_1 = viewModel.AddressInfo!.AddressLine_1,
                            AddressLine_2 = viewModel.AddressInfo.AddressLine_2,
                            PostalCode = viewModel.AddressInfo.PostalCode,
                            City = viewModel.AddressInfo.City
                        };
                        var result = await _addressService.CreateAddressAsync(address);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                            ViewData["ErrorMessage"] = "Something went wrong! Unable to update address information";
                        }
                    }
                }
            }
        }

        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion


    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            ProfileImage = user.ProfileImage!
        };
    }

    #region [HttpPost] UploadProfileImage
    [HttpPost]
    public async Task<IActionResult> UploadProfileImage(UploadProfileImageViewModel viewModel)
    {
        // Check if a file has been uploaded
        if (viewModel.ProfileImage == null || viewModel.ProfileImage.Length == 0)
        {
            ModelState.AddModelError("profileImage", "Please upload an image file.");
        }

        // Check the file's content type to verify it's an image
        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
        if (!allowedContentTypes.Contains(viewModel.ProfileImage!.ContentType))
        {
            ModelState.AddModelError("profileImage", "Please upload a JPEG, PNG, or GIF image.");
        }

        // Check the file's size (optional)
        if (viewModel.ProfileImage.Length > 2 * 1024 * 1024) // 2 MB
        {
            ModelState.AddModelError("profileImage", "The image file size should not exceed 2MB.");
 
        }

        // If the file passed all checks, save it to the disk
        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        if (!Directory.Exists(uploads))
        {
            Directory.CreateDirectory(uploads);
        }

        var filePath = Path.Combine(uploads, viewModel.ProfileImage.FileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await viewModel.ProfileImage.CopyToAsync(fileStream);
        }

        // Update the user's profile image URL in your database
        var user = await _userManager.GetUserAsync(User);
        var fileName = Path.GetFileName(viewModel.ProfileImage!.FileName);
        user!.ProfileImage = "/uploads/" + fileName;
        await _userManager.UpdateAsync(user);

        // Return the new image URL
        return RedirectToAction("Details");
    }
    #endregion

    private async Task<AccountDetailsBasicInfoViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsBasicInfoViewModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Biography = user.Bio
        };
    }

    private async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var address = await _addressService.GetAddressAsync(user.Id);
            if (address != null)
            {
                return new AccountDetailsAddressInfoViewModel
                {
                    AddressLine_1 = address.AddressLine_1,
                    AddressLine_2 = address.AddressLine_2,
                    PostalCode = address.PostalCode,
                    City = address.City,
                };
            }
          
        }

        return new AccountDetailsAddressInfoViewModel();
    }

    #region [HttpGet] Security
    [Route("/account/security")]
    [HttpGet]
    public async Task<IActionResult> Security()
    {
        var viewModel = new AccountSecurityViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        return View(viewModel);
    }
    #endregion

    #region [HttpPost] Security
    [Route("/account/security")]
    [HttpPost]
    public IActionResult Security(AccountSecurityViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        return RedirectToAction("Security", "Account");
    }
    #endregion

    //[Route("/account/security")]
    //[HttpPost]
    //public IActionResult Password(AccountSecurityViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //        return View(viewModel);

    //    //viewModel.ErrorMessage = "Incorrect password";
    //    return RedirectToAction("Security", "Account");
    //}

    #region [HttpGet] SavedCourses
    [Route("/account/savedCourses")]
    [HttpGet]
    public async Task<IActionResult> SavedCourses()
    {
        var viewModel = new AccountSavedCoursesViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        return View(viewModel);
    }
    #endregion


}
