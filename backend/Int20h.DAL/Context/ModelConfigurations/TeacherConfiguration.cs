using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<TeacherInformation>
    {
        public void Configure(EntityTypeBuilder<TeacherInformation> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
