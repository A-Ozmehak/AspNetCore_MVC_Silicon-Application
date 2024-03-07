namespace Infrastructure.Entities;

public class TopToolEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<ToolEntity> Tools { get; set; } = [];
}
