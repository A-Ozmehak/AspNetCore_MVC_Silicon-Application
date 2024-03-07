using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FeatureRepository(DataContext context) : Repo<FeatureEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<FeatureEntity> result = await _context.Features
                .Include(i => i.FeatureItems)
                .ToListAsync();

            return ResponseFactory.Ok(result);
        }
        catch(Exception ex) 
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
