namespace Infrastructure.Entities;

public class FeatureItemEntity
{
    public int Id { get; set; }

    public int FeatureId { get; set; }
    public FeatureEntity Feature { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
}
