using AspNetCore_MVC.ViewModels.Sections;
using AspNetCore_MVC.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCore_MVC.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        //var viewModel = new HomeIndexViewModel
        //{
        //    Title = "Task Management Assistant",
        //    Slider = new SliderViewModel
        //    {
        //        Title = "Switch Between",
        //        Description = "Light & Dark Mode",
        //        Image = new() { ImageUrl = "/images/mockup.svg", AltText = ""}
        //    },
        //    TopTools = new TopToolsViewModel
        //    {
        //        Title = "Integrate Top Work Tools",
        //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
        //        ToolFirstRow =
        //        [
        //            new() { Image = new() { ImageUrl = "/images/icons/google-icon.svg", AltText = "Google logo" }, Text = "Lorem magnis pretium sed curabitur nunc facilisi nuc cursus sagittis." },
        //            new() { Image = new() { ImageUrl = "/images/icons/zoom-icon.svg", AltText = "Zoom logo" }, Text = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor." },
        //            new() { Image = new() { ImageUrl = "/images/icons/slack-icon.svg", AltText = "Slack logo" }, Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
        //            new() { Image = new() { ImageUrl = "/images/icons/gmail-icon.svg", AltText = "Gmail logo" }, Text = "Rutrum interdum tortos, sed at nulla. A cursus bibendum elit purus cras praesent." }
                    
        //        ],
        //        ToolSecondRow =
        //        [
        //            new() { Image = new() { ImageUrl = "/images/icons/trello-icon.svg", AltText = "Trello logo" }, Text = "Congue pellentesque amet, viverra  curabitur quam diam scelerisque fermentum urna." },
        //            new() { Image = new() { ImageUrl = "/images/icons/mailchimp-icon.svg", AltText = "Mailchimp logo" }, Text = "A elementum, imperdiet enum, pretium etiam facilisi in aenean quam maruis." },
        //            new() { Image = new() { ImageUrl = "/images/icons/dropbox-icon.svg", AltText = "Dropbox logo" }, Text = "Lut in turpis consequat odio diam lextus elementum. Est faucibus blandit platea." },
        //            new() { Image = new() { ImageUrl = "/images/icons/evernote-icon.svg", AltText = "Evernote logo" }, Text = "Faucibus cursus maecenas lorem cusus nibh. Sociis sit risus id. Sit facilisis dolor arcu." }
        //        ]
        //    },
        //    Newsletter = new NewsletterViewModel
        //    {
        //        Title = "Don't Want to Miss Anything?",
        //        Arrow = new() { ImageUrl = "/images/arrows.svg", AltText = "Arrow"},
        //        SignUpText = "Sign up for Newsletters",
        //        Link = new() { Text = "Subscribe*", ActionName = "Subscribe", ControllerName = "Home" },
        //    }
        //};      

        //ViewData["Title"] = viewModel.Title;
        return View();
    }


}
