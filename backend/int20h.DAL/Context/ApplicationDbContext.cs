using Int20h.DAL.Context.ModelConfigurations;
using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Int20h.DAL.Context;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
