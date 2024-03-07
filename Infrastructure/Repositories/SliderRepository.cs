using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SliderRepository(DataContext context) : Repo<SliderEntity>(context)
{
    private readonly DataContext _context = context;
}
