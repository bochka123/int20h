using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            var roles = new Role[]
            {
                new()
                {
                    Name = "admin",
                    Id = Guid.NewGuid()
                },
                new()
                {
                    Name = "teacher",
                    Id = Guid.NewGuid()
                },
                new()
                {
                    Name = "student",
                    Id = Guid.NewGuid()
                }
            };
            builder.HasData(roles);
        }
    }
}
