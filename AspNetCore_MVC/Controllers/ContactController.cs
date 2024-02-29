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
        var viewModel = new ContactViewModel
        {
            Title = "Contact us",
            Content = new ContactContentViewModel
            {
                Option = 
                  [
                    new() { Icon = "fa-regular fa-envelope", ContactReason = "Email us", Text = "Please feel free to drop us a line. We will respond as soon as possible", Link = new() { Text = "Leave a message", Icon = "fa-solid fa-arrow-right", ActionName = "", ControllerName = "" } },
                    new() { Icon = "fa-solid fa-user-plus", ContactReason = "Careers", Text = "Sit ac ipsum leo lorem magna nunc mattis maecenas non vestibulum", Link = new() { Text = "Send an application", Icon = "fa-solid fa-arrow-right", ActionName = "", ControllerName = "" } }
                  ]
            }
        };
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    public IActionResult Index(ContactViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("Index", "Contact");
    }
}
