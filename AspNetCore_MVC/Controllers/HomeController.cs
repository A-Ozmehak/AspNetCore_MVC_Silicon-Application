using AspNetCore_MVC.ViewModels.Sections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;



namespace AspNetCore_MVC.Controllers;

public class HomeController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    public IActionResult Index()
    {
        var viewModel = new NewsletterViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(NewsletterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7106/api/subscribers?key=OTk3MTM3MmUtZWFlMi00ODYyLWFhZDMtNTI1OWIyZWY5NTNl", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Status"] = "Success";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    ViewData["Status"] = "AlreadyExists";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ViewData["Status"] = "Unauthorized";
                }
            }
            catch
            {
                ViewData["Status"] = "ConnectionFailed";
            }
        }
        else
        {
            ViewData["Status"] = "Invalid";
        }
        return View(viewModel);
    }

}
