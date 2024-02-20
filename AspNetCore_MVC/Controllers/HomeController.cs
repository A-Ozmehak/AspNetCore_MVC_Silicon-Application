using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Task Management Assistant",
            Showcase = new ShowcaseViewModel
            {
                Id = "overview",
                ShowcaseImage = new() { ImageUrl = "/images/showcase-background.svg", AltText = "Task Management Assistant" },
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                BrandsText = "Largest companies use our tool to work efficiently.",
                Link = new() { ControllerName = "Account", ActionName = "SignUp", Text = "Get started for free" },
                Brands =
                   [
                       new() { ImageUrl = "/images/brands/brand1.svg", AltText = "Brand name 1" },
                       new() { ImageUrl = "/images/brands/brand2.svg", AltText = "Brand name 2" },
                       new() { ImageUrl = "/images/brands/brand3.svg", AltText = "Brand name 3" },
                       new() { ImageUrl = "/images/brands/brand4.svg", AltText = "Brand name 4" }
                   ],
            }
        };
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

}
