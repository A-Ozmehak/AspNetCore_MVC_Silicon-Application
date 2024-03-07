using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ToolRepository(DataContext context) : Repo<ToolEntity>(context)
{
    private readonly DataContext _context = context;
}
