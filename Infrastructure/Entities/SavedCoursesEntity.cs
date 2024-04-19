using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SavedCoursesEntity
{
    public string UserId { get; set; } = null!;
    public string CourseId { get; set; } = null!;
}
