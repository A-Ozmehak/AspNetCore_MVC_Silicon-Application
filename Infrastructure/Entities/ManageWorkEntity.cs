namespace Infrastructure.Entities;

public class ManageWorkEntity
{
    public int Id { get; set; }
    public string Image { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ICollection<TextIconEntity> TextAndIcon { get; set; } = [];
}
