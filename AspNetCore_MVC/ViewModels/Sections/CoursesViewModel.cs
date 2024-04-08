using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class CoursesViewModel
{
    public List<CourseViewModel> Courses { get; set; } = null!;
}
