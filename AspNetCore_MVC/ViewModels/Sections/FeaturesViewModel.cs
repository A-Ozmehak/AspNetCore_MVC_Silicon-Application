using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class FeaturesViewModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public List<BoxViewModel> Box { get; set; } = null!;
}
