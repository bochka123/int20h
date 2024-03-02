using Int20h.DAL.Context.ModelConfigurations;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Int20h.DAL.Context;

public class ApplicationDbContext: IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<StudentInformation> StudentInformations { get; set; }
    public DbSet<TeacherInformation> TeacherInformations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
