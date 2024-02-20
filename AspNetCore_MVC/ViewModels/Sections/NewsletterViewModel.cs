using AspNetCore_MVC.Models.Components;
using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class NewsletterViewModel
{
    public string Title { get; set; } = null!;
    public ImageViewModel Arrow { get; set; } = null!;

    public string SignUpText { get; set; } = null!;

    public NewsletterModel Form { get; set; } = new NewsletterModel();
    public LinkViewModel Link { get; set; } = null!;
}
