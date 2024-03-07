using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class TextIconRepository(DataContext context) : Repo<TextIconEntity>(context)
{
    private readonly DataContext _context = context;
}
