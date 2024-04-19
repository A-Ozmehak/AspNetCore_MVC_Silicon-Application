using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCore_MVC.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    #region [HttpGet] Index

    [Route("/contact")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region [HttpPost] Index
    [HttpPost]
    public async Task<IActionResult> Index(ContactViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7106/api/contact?key=OTk3MTM3MmUtZWFlMi00ODYyLWFhZDMtNTI1OWIyZWY5NTNl", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Status"] = "Success";
                    return View(new ContactViewModel());
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

    #endregion
}
