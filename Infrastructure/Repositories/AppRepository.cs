using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AppRepository(DataContext context) : Repo<AppEntity>(context)
{
    private readonly DataContext _context = context;

}
