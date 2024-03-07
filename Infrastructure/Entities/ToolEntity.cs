namespace Infrastructure.Entities;

public class ToolEntity
{
    public int Id { get; set; }

    public int TopToolId { get; set; }
    public TopToolEntity TopTool { get; set; } = null!;

    public string Image { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Text { get; set; } = null!;
}
