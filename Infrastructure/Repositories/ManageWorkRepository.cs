using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ManageWorkRepository(DataContext context) : Repo<ManageWorkEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
       try
        {
            IEnumerable<ManageWorkEntity> result = await _context.Manage
                .Include(i => i.TextAndIcon)
                .ToListAsync();

            return ResponseFactory.Ok(result);
        }
        catch(Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}
