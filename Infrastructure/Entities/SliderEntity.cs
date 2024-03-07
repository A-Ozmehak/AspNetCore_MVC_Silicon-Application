namespace Infrastructure.Entities;

public class SliderEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string AltText { get; set; } = null!;
}
