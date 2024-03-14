using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

[Authorize]
public class CoursesController : Controller
{
    [Route("/courses")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/courses/1")]
    public IActionResult Detail()
    {
        return View();
    }
}
