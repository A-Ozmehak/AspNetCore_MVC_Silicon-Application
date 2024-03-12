using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AccountService(DataContext context)
{
    private readonly DataContext _context = context;


}
