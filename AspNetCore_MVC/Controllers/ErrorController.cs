using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
