using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class BrandRepository(DataContext context) : Repo<BrandEntity>(context)
{
    private readonly DataContext _context = context;

}
