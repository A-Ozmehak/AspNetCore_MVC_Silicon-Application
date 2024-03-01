namespace AspNetCore_MVC.ViewModels.Components;

public class ContactOptionViewModel
{
    public string Icon { get; set; } = null!;
    public string ContactReason { get; set; } = null!;
    public string Text { get; set; } = null!;
    public LinkViewModel Link { get; set; } = null!;
}
