using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

public class SaveCoursesRepository(DataContext context) : Repo<SavedCoursesEntity>(context)
{
    private readonly DataContext _context = context;

    public async Task<ResponseResult> SaveCourseAsync(string userId, string courseId)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(courseId))
        {
            return ResponseFactory.Error("UserId and CourseId cannot be null or empty.");
        }

        try
        {
            var savedCourse = new SavedCoursesEntity
            {
                UserId = userId,
                CourseId = courseId
            };

            return await CreateOneAsync(savedCourse);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }
}
