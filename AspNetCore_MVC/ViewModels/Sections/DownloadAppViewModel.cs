using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class DownloadAppViewModel
{
    public ImageViewModel MobileImage { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<AppViewModel> App { get; set; } = null!;
}
