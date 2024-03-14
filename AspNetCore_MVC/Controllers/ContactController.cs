using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class ContactController : Controller
{
    [Route("/contact")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index(ContactViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("Index", "Contact");
    }
}
