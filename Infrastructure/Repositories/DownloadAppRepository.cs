using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DownloadAppRepository(DataContext context) : Repo<DownloadAppEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<DownloadAppEntity> result = await _context.DownloadApp
                .Include(i => i.App)
                .ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

}
