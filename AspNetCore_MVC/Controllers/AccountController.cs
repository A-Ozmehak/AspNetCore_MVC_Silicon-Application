using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class AccountController : Controller
{
    //private readonly AccountService _accountService;

    //public AccountController(AccountService accountService)
    //{
    //    _accountService = accountService;
    //}

    [Route("/account")]
    [HttpGet]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        //viewModel.BasicInfo = _accountService.GetBasicInfo();
        //viewModel.AddressInfo = _accountService.GetAddressInfo();

        return View(viewModel);
    }

    [Route("/account")]
    [HttpPost]
    public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
    {
        //_accountService.SaveBasicInfo(viewModel.BasicInfo);
        return RedirectToAction(nameof(Details), viewModel);
    }

    [Route("/account")]
    [HttpPost]
    public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
    {
        //_accountService.SaveAddressInfo(viewModel.AddressInfo);
        return RedirectToAction(nameof(Details), viewModel);
    }

    [Route("/account/security")]
    [HttpGet]
    public IActionResult Security()
    {
        var viewModel = new AccountSecurityViewModel();
        //viewModel.BasicInfo = _accountService.GetBasicInfo();
        //viewModel.AddressInfo = _accountService.GetAddressInfo();

        return View(viewModel);
    }

    [Route("/account/security")]
    [HttpPost]
    public IActionResult Password(AccountSecurityViewModel viewModel)
    {
        if (ModelState.IsValid)
            return View(viewModel);

        viewModel.ErrorMessage = "Incorrect password";
        return RedirectToAction("Security", "Account");
    }
}
