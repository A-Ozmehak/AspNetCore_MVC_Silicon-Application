using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult Error(int statusCode)
    {
        return View(statusCode);
    }
}
