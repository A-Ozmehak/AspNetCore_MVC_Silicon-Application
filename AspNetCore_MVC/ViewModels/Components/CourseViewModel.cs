namespace AspNetCore_MVC.ViewModels.Components;

public class CourseViewModel
{
    public ImageViewModel Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public double Price { get; set; }
    public string Duration { get; set; } = null!;
    public string Rating { get; set; } = null!;
}
