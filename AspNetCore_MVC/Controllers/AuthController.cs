using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class AuthController : Controller
{
    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        //var result = _authService.SignIn(viewModel.Form);
        //if (result)
        //    return RedirectToAction("Account", "Index");

        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);


    }
}
