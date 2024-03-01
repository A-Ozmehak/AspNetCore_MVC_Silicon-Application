using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class SingleCourseViewModel
{
    public ImageViewModel CourseImage { get; set; } = null!;
    public string? Tag { get; set; }
    public string Category { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Likes { get; set; } = null!;
    public string Duration { get; set; } = null!;
    public ImageViewModel AuthorImage { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public List<IconWithTextViewModel> CourseGoals { get; set; } = null!;
    public List<TitleAndDescriptionViewModel> CourseSteps { get; set; } = null!;
    public List<IconWithTextViewModel> CourseIncludes { get; set; } = null!;
    public double Price { get; set; }
    public double? DiscountPrice { get; set; }

}
