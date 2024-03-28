using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class ContactController : Controller
{
    #region [HttpGet] Index
    [Route("/contact")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region [HttpPost] Index
    public IActionResult Index(ContactViewModel viewModel)
    {
        if (ModelState.IsValid)
            return View(viewModel);

        ModelState.AddModelError("IncorrectValues", "You must provide a name, a valid email and a message");
        ViewData["ErrorMessage"] = "You must provide a name, a valid email and a message";
        return View(viewModel);
    }

    #endregion
}
