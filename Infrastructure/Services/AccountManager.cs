using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountManager(UserManager<UserEntity> userManager, DataContext context, IConfiguration configuration, SaveCoursesRepository saveCoursesRepository)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly SaveCoursesRepository _saveCoursesRepository = saveCoursesRepository;

    public async Task<bool> UploadUserProfileImage(ClaimsPrincipal user, IFormFile file)
    {
        try
        {
            if (user != null && file != null && file.Length != 0)
            {
                var userEntity = await _userManager.GetUserAsync(user);

                if (userEntity != null)
                {
                    var fileName = $"p_{userEntity.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    userEntity.ProfileImage = fileName;
                    _context.Update(userEntity);
                    await _context.SaveChangesAsync();

                    return true;
                    
                }
            }
        }
        catch(Exception ex) 
        { 
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public async Task<ResponseResult> ToggleSaveCourseAsync(string userId, string courseId)
    {
        try
        {
            var savedCourse = await _context.SavedCourses
                .FirstOrDefaultAsync(sc => sc.UserId == userId && sc.CourseId == courseId);

            if (savedCourse != null)
            {
                _context.SavedCourses.Remove(savedCourse);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok();
            }
            else
            {
                savedCourse = new SavedCoursesEntity { UserId = userId, CourseId = courseId };
                _context.SavedCourses.Add(savedCourse);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok();
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<IEnumerable<SavedCoursesEntity>> GetSavedCoursesAsync(string userId)
    {
        var savedCourses = await _context.SavedCourses
            .Where(sc => sc.UserId == userId)
            .ToListAsync();

        return savedCourses;
    }

    public async Task<ResponseResult> DeleteAllSavedCoursesAsync(string userId)
    {
        try
        {
            var savedCourses = await _context.SavedCourses
                .Where(sc => sc.UserId == userId)
                .ToListAsync();

            _context.SavedCourses.RemoveRange(savedCourses);
            await _context.SaveChangesAsync();

            return ResponseFactory.Ok();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
