using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCore_MVC.Controllers;

[Authorize]
public class CoursesController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    [Route("/courses")]
    public async Task<IActionResult> Index()
    {
            try
            {
                var response = await http.GetAsync("https://localhost:7106/api/courses?key=OTk3MTM3MmUtZWFlMi00ODYyLWFhZDMtNTI1OWIyZWY5NTNl");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var courses = JsonConvert.DeserializeObject<List<CourseViewModel>>(content);
                    var coursesViewModel = new CoursesViewModel { Courses = courses };
                    return View(coursesViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ViewData["Status"] = "Unauthorized";
                }
                else
                {
                    ViewData["Status"] = "Error";
                }
            }
            catch
            {
                ViewData["Status"] = "ConnectionFailed";
            }
        return View(new CoursesViewModel { Courses = new List<CourseViewModel>() });
    }


    [Route("/courses/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        try
        {
            var response = await _http.GetAsync($"https://localhost:7106/api/courses/{id}?key=OTk3MTM3MmUtZWFlMi00ODYyLWFhZDMtNTI1OWIyZWY5NTNl");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var course = JsonConvert.DeserializeObject<CourseViewModel>(content);
                return View(course);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ViewData["Status"] = "NotFound";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ViewData["Status"] = "Unauthorized";
            }
            else
            {
                ViewData["Status"] = "Error";
            }
        }
        catch
        {
            ViewData["Status"] = "ConnectionFailed";
        }

        return View(new CourseViewModel());
    }
}
