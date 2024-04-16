using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Views;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var user = await _userManager.GetUserAsync(User);
        var address = await _addressService.GetAddressAsync(userId!);

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = user != null ? new AccountDetailsBasicInfoViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                Phone = user.PhoneNumber,
                Biography = user.Bio
            } : null,
            AddressInfo = address != null ? new AccountDetailsAddressInfoViewModel
            {
                AddressLine_1 = address.AddressLine_1,
                AddressLine_2 = address.AddressLine_2,
                PostalCode = address.PostalCode,
                City = address.City,
            } : null,
            ProfileInfo = new ProfileInfoViewModel
            {
                ProfileImage = user!.ProfileImage!
            },
            IsExternalAccount = user.IsExternalAccount
        };

        return View(viewModel);
    }
    #endregion

    #region HttpPost Details

    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.GetUserAsync(User);
        var address = await _addressService.GetAddressAsync(userId!);

        if (ModelState.IsValid)
        {
            if (viewModel.BasicInfo != null)
            {
                await UpdateBasicInfo(viewModel.BasicInfo);
            }
            else if (user != null)
            {
                viewModel.BasicInfo = new AccountDetailsBasicInfoViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    Phone = user.PhoneNumber,
                    Biography = user.Bio
                };
            }

            if (viewModel.AddressInfo != null)
            {
                await UpdateAddressInfo(viewModel.AddressInfo);
            }
            else if (address != null)
            {
                viewModel.AddressInfo = new AccountDetailsAddressInfoViewModel
                {
                    AddressLine_1 = address.AddressLine_1,
                    AddressLine_2 = address.AddressLine_2,
                    PostalCode = address.PostalCode,
                    City = address.City,
                };
            }

            return RedirectToAction("Details");
        }

        return View(viewModel);
    }

    #endregion

    public async Task UpdateBasicInfo(AccountDetailsBasicInfoViewModel viewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        user!.FirstName = viewModel.FirstName;
        user.LastName = viewModel.LastName;
        user.Email = viewModel.Email;
        user.PhoneNumber = viewModel.Phone;
        user.Bio = viewModel.Biography;

        await _userManager.UpdateAsync(user);
    }

    public async Task UpdateAddressInfo(AccountDetailsAddressInfoViewModel viewModel)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var address = await _addressService.GetAddressAsync(userId!);
        if (address != null)
        {
            address.AddressLine_1 = viewModel.AddressLine_1;
            address.AddressLine_2 = viewModel.AddressLine_2;
            address.PostalCode = viewModel.PostalCode;
            address.City = viewModel.City;

            await _addressService.UpdateAddressAsync(address);
        }
        else
        {
            var newAddress = new AddressEntity
            {
                UserId = userId!,
                AddressLine_1 = viewModel.AddressLine_1,
                AddressLine_2 = viewModel.AddressLine_2,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,
            };

            await _addressService.CreateAddressAsync(newAddress);
        }
    }


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
