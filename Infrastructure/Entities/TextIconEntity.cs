namespace Infrastructure.Entities;

public class TextIconEntity
{
    public int Id { get; set; }

    public int ManageWorkId { get; set; }
    public ManageWorkEntity ManageWork { get; set; } = null!;

    public string Icon { get; set; } = null!;
    public string Text { get; set; } = null!;
}
