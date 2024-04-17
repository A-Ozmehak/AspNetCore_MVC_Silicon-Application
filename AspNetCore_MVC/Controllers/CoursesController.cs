using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AspNetCore_MVC.Controllers;

[Authorize]
public class CoursesController(HttpClient http, IConfiguration configuration) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    #region Index

    [Route("/courses")]
    public async Task<IActionResult> Index()
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync($"https://localhost:7106/api/courses?key={_configuration["ApiKey"]}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var courses = JsonConvert.DeserializeObject<List<CourseViewModel>>(content);
                var coursesViewModel = new CoursesViewModel { Courses = courses };
                return View(coursesViewModel);
            }
        }

        return View(new CoursesViewModel { Courses = new List<CourseViewModel>() });
    }

    #endregion

    #region Detail

    [Route("/courses/{id}")]
    public async Task<IActionResult> Detail(string id)
    {
        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync($"https://localhost:7106/api/courses/{id}?key={_configuration["ApiKey"]}");
            if (response.IsSuccessStatusCode)
            {
                var course = JsonConvert.DeserializeObject<CourseViewModel>(await response.Content.ReadAsStringAsync());
                return View(course);
            }
        }

        return View();
    }

    #endregion
}
