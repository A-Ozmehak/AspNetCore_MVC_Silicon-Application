using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountManager(UserManager<UserEntity> userManager, DataContext context, IConfiguration configuration)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;

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
}
