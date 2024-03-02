using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class StudentInformationConfiguration : IEntityTypeConfiguration<StudentInformation>
    {
        public void Configure(EntityTypeBuilder<StudentInformation> builder)
        {
            builder
                .HasOne(s => s.User)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);
        }
    }
}
