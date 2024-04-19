﻿using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Views;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCore_MVC.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, IWebHostEnvironment hostingEnvironment, AddressService addressService, AccountManager accountManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
    private readonly AddressService _addressService = addressService;
    private readonly AccountManager _accountManager = accountManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

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
                Biography = user.Bio,
            } : null,
            AddressInfo = address != null ? new AccountDetailsAddressInfoViewModel
            {
                AddressLine_1 = address.AddressLine_1,
                AddressLine_2 = address.AddressLine_2,
                PostalCode = address.PostalCode,
                City = address.City,
            } : null,
            IsExternalAccount = user!.IsExternalAccount
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

    #region [HttpPost] UploadProfileImage

    [HttpPost]
    public async Task<IActionResult> UploadProfileImage(UploadProfileImageViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountManager.UploadUserProfileImage(User, model.ProfileImage!);
            if (result)
            {
                return RedirectToAction("Details", "Account");
            }
            else
            {
                ModelState.AddModelError("", "There was an error uploading the image.");
            }
        }

        return View(model);
    }

    #endregion


    #region [HttpGet] Security
    [Route("/account/security")]
    [HttpGet]
    public IActionResult Security()
    {
        return View();
    }
    #endregion

    #region [HttpPost] Security
    [Route("/account/security")]
    [HttpPost]
    public async Task<IActionResult> Security(AccountSecurityViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, viewModel.Password!.CurrentPassword, viewModel.Password.NewPassword);
                if (result.Succeeded)
                {
                    // If the password was successfully changed, redirect the user to a confirmation page
                    return RedirectToAction("Security", "Account");
                }
                else
                {
                    // If there was an error changing the password, add the errors to the ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Invalid new password", error.Description);
                    }
                }
            }
        }

        return View(viewModel);
    }
    #endregion

    #region DeleteAccount

    [HttpPost]
    public async Task<IActionResult> DeleteAccount(AccountSecurityViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.DeleteAccount!.Delete)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
        }

        return View(model);
    }

    #endregion




    #region [HttpGet] SavedCourses
    [Route("/account/savedCourses")]
    [HttpGet]
    public IActionResult SavedCourses()
    {
        return View();
    }
    #endregion


}
