namespace Infrastructure.Entities;

public class ShowcaseEntity
{
    public int Id { get; set; }
    public string ShowcaseImage { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

    public string BrandsText { get; set; } = null!;
    public ICollection<BrandEntity> Brands { get; set; } = [];
}
