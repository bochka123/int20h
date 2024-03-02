using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roles = new Role[]
            {
                new()
                {
                    Name = "admin",
                },
                new()
                {
                    Name = "teacher"
                },
                new()
                {
                    Name = "student"
                }
            };
            builder.HasData(roles);
        }
    }
}
