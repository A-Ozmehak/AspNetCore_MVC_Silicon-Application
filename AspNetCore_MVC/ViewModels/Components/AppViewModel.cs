namespace AspNetCore_MVC.ViewModels.Components;

public class AppViewModel
{
    public string StoreName { get; set; } = null!;
    public string AwardTitle { get; set; } = null!;
    public string AwardRating { get; set; } = null!;
    public ImageViewModel StoreImage { get; set; } = null!;
}
