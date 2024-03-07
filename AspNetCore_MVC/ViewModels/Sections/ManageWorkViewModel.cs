using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class ManageWorkViewModel
{
    //public ImageViewModel Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<IconWithTextViewModel> IconAndText { get; set; } = null!;
    public LinkViewModel? Link { get; set; }
}
