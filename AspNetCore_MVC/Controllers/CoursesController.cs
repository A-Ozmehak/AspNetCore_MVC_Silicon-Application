using AspNetCore_MVC.ViewModels.Components;
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
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Tag = "Best Seller", SaveIcon = "fa-solid fa-tag",  Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, SalesPrice = 10.99, Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Tag = "Best Seller", SaveIcon = "fa-solid fa-tag", Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, Duration = "220 hours", Rating = "94% (4.2K)" },
                    new() { Image = new() { ImageUrl = "/images/course1.svg", AltText = "course1" }, Tag = "Best Seller", SaveIcon = "fa-solid fa-tag", Title = "Fullstack Web Developer Course from Scratch", Author = "by Robert Fox", Price = 12.50, Duration = "220 hours", Rating = "94% (4.2K)" },
                ]
            }, 
            Banner = new() { Question = "Ready to get started?", FirstPartTitle = "Take Your ", ColoredTitle = "Skills", SecondPartTitle = " to the Next Level", Link = new() { Text = "Work with us", ControllerName = "", ActionName = "" }, Image = new() { ImageUrl = "/images/illustration.svg", AltText = "Illustration" } }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    [Route("/courses/1")]
    public IActionResult Detail()
    {
        var viewModel = new SingleCourseViewModel
        {
            CourseImage = new() { ImageUrl = "/images/course1-bg.svg", AltText = "Course image" },
            Tag = "Best Seller",
            Category = "Digital",
            Title = "Fullstack Web Developer Course from Scratch",
            Description = "Egestas feugiat lorem eu neque suspendisse ullamcorper scelerisque aliquam mauris.",
            Likes = "5K likes",
            Duration = "148 hours",
            AuthorImage = new() { ImageUrl = "/images/author-img.svg", AltText = "" },
            AuthorName = "Albert Flores",
            CourseDescription = "Suspendisse natoque sagittis, consequat turpis. Sed tristique tellus morbi magna. At vel senectus accumsan, arcu mattis id tempor. Tellus sagittis, euismod porttitor sed tortor est id. Feugiat velit velit, tortor ut. Ut libero cursus nibh lorem urna amet tristique leo. Viverra lorem arcu nam nunc at ipsum quam. A proin id sagittis dignissim mauris condimentum ornare. Tempus mauris sed dictum ultrices.",
            CourseGoals = new List<IconWithTextViewModel>
            {
                new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Sed lectus donec amet eu turpis interdum." },
                new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Nulla at consectetur vitae dignissim porttitor." },
                new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Phasellus id vitae dui aliquet mi." },
                new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "Integer cursus vitae, odio feugiat iaculis aliquet diam, et purus." },
                new() { Icon = "fa-sharp fa-regular fa-circle-check", Text = "In aenean dolor diam tortor orci eu." },
            },
            CourseSteps = new List<TitleAndDescriptionViewModel> 
            {
                new() { StepNumber = "1", Title = "Introduction. Getting started", Description = "Nulla faucibus mauris pellentesque blandit faucibus non. Sit ut et at suspendisse gravida hendrerit tempus placerat." },
                new() { StepNumber = "2", Title = "The ultimate HTML developer: advanced HTML", Description = "Lobortis diam elit id nibh ultrices sed penatibus donec. Nibh iaculis eu sit cras ultricies. Nam eu eget etiam egestas donec scelerisque ut ac enim. Vitae ac nisl, enim nec accumsan vitae est." },
                new() { StepNumber = "3", Title = "CSS & CSS3: basic", Description = "Duis euismod enim, facilisis risus tellus pharetra lectus diam neque. Nec ultrices mi faucibus est. Magna ullamcorper potenti elementum ultricies auctor nec volutpat augue." },
                new() { StepNumber = "4", Title = "JavaScript basics for beginners", Description = "Morbi porttitor risus imperdiet a, nisl mattis. Amet, faucibus eget in platea vitae, velit, erat eget velit. At lacus ut proin erat." },
                new() { StepNumber = "5", Title = "Understanding APIs", Description = "Risus morbi euismod in congue scelerisque fusce pellentesque diam consequat. Nisi mauris nibh sed est morbi amet arcu urna. Malesuada feugiat quisque consectetur elementum diam vitae. Dictumst facilisis odio eu quis maecenas risus odio fames bibendum." },
                new() { StepNumber = "6", Title = "C# and .NET from beginner to advanced", Description = "Quis risus quisque diam diam. Volutpat neque eget eu faucibus sed urna fermentum risus. Est, mauris morbi nibh massa." }
            },
            CourseIncludes = new List<IconWithTextViewModel> 
            {
                new() { Icon = "fa-solid fa-display", Text = "148 hours on-demand video" },
                new() { Icon = "fa-regular fa-newspaper", Text = "18 articles" },
                new() { Icon = "fa-solid fa-download", Text = "25 downloadable resources" },
                new() { Icon = "fa-solid fa-infinity", Text = "Full lifetime access" },
                new() { Icon = "fa-solid fa-trophy", Text = "Certificate of completion" }
            },
            Price = 49.00,
            DiscountPrice = 28.99
        };

        return View(viewModel);
    }
}
