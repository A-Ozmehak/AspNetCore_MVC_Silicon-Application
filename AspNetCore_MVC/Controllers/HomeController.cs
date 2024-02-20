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
            },
            Features = new FeaturesViewModel
            {
                Id = "features",
                Title = "What Do You Get with Our Tool?",
                Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
                Box =
                [
                  new() { BoxImage = new() { ImageUrl = "/images/icons/comments-icon.svg", AltText = "" }, Title = "Comments on Tasks", Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
                  new() { BoxImage = new() { ImageUrl = "/images/icons/tasks-analytics-icon.svg", AltText = "" }, Title = "Tasks Analytics", Description = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate." },
                  new() { BoxImage = new() { ImageUrl = "/images/icons/multiple-assignees-icon.svg", AltText = "" }, Title = "Multiple Assignees", Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
                  new() { BoxImage = new() { ImageUrl = "/images/icons/notifications-icon.svg", AltText = "" }, Title = "Notifications", Description = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra." },
                  new() { BoxImage = new() { ImageUrl = "/images/icons/sections-icon.svg", AltText = "" }, Title = "Sections & Subtasks", Description = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus." },
                  new() { BoxImage = new() { ImageUrl = "/images/icons/data-security-icon.svg", AltText = "" }, Title = "Data Security", Description = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras." },
                ]
            },
            Slider = new SliderViewModel
            {
                Title = "Switch Between",
                Description = "Light & Dark Mode",
                Image = new() { ImageUrl = "/images/mockup.svg", AltText = ""}
            },
            ManageWork = new ManageWorkViewModel
            {
                Image = new() { ImageUrl = "/images/manage-work.svg", AltText = ""},
                Title = "Manage Your Work",
                IconAndText =
                [
                    new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Powerful project management" },
                    new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Transparent work management" },
                    new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Manage work & focus on the most important tasks" },
                    new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Track your process with interactive charts" },
                    new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Easiest way to track time spent on tasks" },
                ],
                Link = new() { Text = "Learn more", ActionName = "", ControllerName = "", Icon = "fa-solid fa-arrow-right" },
               
            }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

}
