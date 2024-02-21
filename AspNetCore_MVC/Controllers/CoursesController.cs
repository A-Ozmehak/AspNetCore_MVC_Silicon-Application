using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class CoursesController : Controller
{
    [Route("/courses")]
    public IActionResult Index()
    {
        var viewModel = new CoursesIndexViewModel
        {
            Title = "Courses",
            Course = new CoursesViewModel
            {
                Course = 
                [
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, Duration = "220 hours", Rating = "94% (4.2K)" },
                ]
            },
            

            Banner = new() { Question = "Ready to get started?", FirstPartTitle = "Take Your ", ColoredTitle = "Skills", SecondPartTitle = " to the Next Level", Link = new() { Text = "Work with us", ControllerName = "", ActionName = "" }, Image = new() { ImageUrl = "/images/illustration.svg", AltText = "Illustration" } }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
