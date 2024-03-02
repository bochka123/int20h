using Int20h.Common.Enums;
using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Role = Int20h.DAL.Entities.Role;

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
                    Name = Roles.Admin,
                    Id = Guid.NewGuid()
                },
                new()
                {
                    Name = Roles.Teacher,
                    Id = Guid.NewGuid()
                },
                new()
                {
                    Name = Roles.Student,
                    Id = Guid.NewGuid()
                }
            };
            builder.HasData(roles);
        }
    }
}
