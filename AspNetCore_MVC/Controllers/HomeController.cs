using AspNetCore_MVC.ViewModels.Sections;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCore_MVC.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = "Task Management Assistant";
        return View();
    }

    [HttpPost]
    public IActionResult Subscribe(NewsletterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");

        }

        ModelState.AddModelError("IncorrectValues", "Provide a correct email address");
        ViewData["ErrorMessage"] = "Provide a correct email address";
        return RedirectToAction("Index");
    }

}
