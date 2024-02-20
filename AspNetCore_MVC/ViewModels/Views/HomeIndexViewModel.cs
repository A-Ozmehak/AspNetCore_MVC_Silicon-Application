using AspNetCore_MVC.ViewModels.Sections;

namespace AspNetCore_MVC.ViewModels.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;
}
