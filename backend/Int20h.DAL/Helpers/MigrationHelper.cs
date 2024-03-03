using Int20h.Common.Enums;
using Int20h.DAL.Context;
using Int20h.DAL.Entities;
using Int20h.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Int20h.DAL.Helpers;

public class MigrationHelper : IMigrationHelper
{
	private readonly RoleManager<IdentityRole<Guid>> _roleManager;
	private readonly ApplicationDbContext _context;
    public MigrationHelper(RoleManager<IdentityRole<Guid>> roleManager, ApplicationDbContext context)
    {
		_roleManager = roleManager;
		_context = context;
    }
    public void Migrate()
    {
        if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
        {
            _context.Database.Migrate();
        }

		if (!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
		{
			_roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Teacher)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Student)).GetAwaiter().GetResult();
		}
	}
}
