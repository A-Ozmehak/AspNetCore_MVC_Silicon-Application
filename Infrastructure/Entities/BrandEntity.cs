namespace Infrastructure.Entities;

public class BrandEntity
{
    public int Id { get; set; }

    public int ShowcaseId { get; set; }
    public ShowcaseEntity Showcase { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
    public string AltText { get; set; } = null!;
}
