using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCore_MVC.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        //var viewModel = new HomeIndexViewModel
        //{
        //    Title = "Task Management Assistant",
        //    Slider = new SliderViewModel
        //    {
        //        Title = "Switch Between",
        //        Description = "Light & Dark Mode",
        //        Image = new() { ImageUrl = "/images/mockup.svg", AltText = ""}
        //    },
   
        //    Newsletter = new NewsletterViewModel
        //    {
        //        Title = "Don't Want to Miss Anything?",
        //        Arrow = new() { ImageUrl = "/images/arrows.svg", AltText = "Arrow"},
        //        SignUpText = "Sign up for Newsletters",
        //        Link = new() { Text = "Subscribe*", ActionName = "Subscribe", ControllerName = "Home" },
        //    }
        //};      

        //ViewData["Title"] = viewModel.Title;
        return View();
    }


}
