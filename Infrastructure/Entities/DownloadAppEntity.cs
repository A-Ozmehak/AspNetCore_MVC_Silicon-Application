namespace Infrastructure.Entities;

public class DownloadAppEntity
{
    public int Id { get; set; }
    public string MobileImage { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ICollection<AppEntity> App { get; set; } = [];
}
