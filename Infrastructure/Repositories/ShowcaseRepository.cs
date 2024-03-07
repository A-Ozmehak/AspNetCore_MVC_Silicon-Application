using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShowcaseRepository(DataContext context) : Repo<ShowcaseEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<ShowcaseEntity> result = await _context.Showcase
                .Include(i => i.Brands) 
                .ToListAsync();

            return ResponseFactory.Ok(result);
        }
        catch(Exception ex) 
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
