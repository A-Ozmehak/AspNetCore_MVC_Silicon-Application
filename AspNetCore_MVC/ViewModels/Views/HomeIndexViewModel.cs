using AspNetCore_MVC.ViewModels.Sections;

namespace AspNetCore_MVC.ViewModels.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;
    public FeaturesViewModel Features { get; set; } = null!;
    public SliderViewModel Slider { get; set; } = null!;
    public ManageWorkViewModel ManageWork { get; set; } = null!;
    public DownloadAppViewModel DownloadApp { get; set; } = null!;
    public TopToolsViewModel TopTools { get; set; } = null!;
    public NewsletterViewModel Newsletter { get; set; } = null!;
}
