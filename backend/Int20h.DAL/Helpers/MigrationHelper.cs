using Int20h.DAL.Context;
using Int20h.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Int20h.DAL.Helpers;

public class MigrationHelper : IMigrationHelper
{
    private readonly ApplicationDbContext _context;
    public MigrationHelper(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Migrate()
    {
        if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
        {
            _context.Database.Migrate();
        }
    }
}
