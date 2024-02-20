using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class TopToolsViewModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public List<ToolViewModel> ToolFirstRow { get; set; } = null!;
    public List<ToolViewModel> ToolSecondRow { get; set; } = null!;
}
