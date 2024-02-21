namespace AspNetCore_MVC.ViewModels.Components;

public class BannerViewModel
{
    public string Question { get; set; } = null!;
    public string FirstPartTitle { get; set; } = null!;
    public string ColoredTitle { get; set; } = null!;
    public string SecondPartTitle { get; set; } = null!;
    public LinkViewModel Link { get; set; } = null!;
    public ImageViewModel Image { get; set; } = null!;
}
