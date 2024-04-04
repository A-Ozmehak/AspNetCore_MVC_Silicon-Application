namespace Infrastructure.Entities;

public class AppEntity
{
    public int Id { get; set; }

    public int DownloadAppId { get; set; }
    public DownloadAppEntity DownloadApp { get; set; } = null!;

    public string StoreName { get; set; } = null!;
    public string AwardTitle { get; set; } = null!;
    public string AwardRating { get; set; } = null!;
    public string StoreImage { get; set; } = null!;
    public string? StoreImageDark { get; set; }
    public string AltText { get; set; } = null!;
}
