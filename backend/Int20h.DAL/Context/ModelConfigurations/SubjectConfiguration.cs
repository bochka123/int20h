using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Tests)
                .WithOne(x => x.Subject)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Teachers)
                .WithMany(x => x.Subjects)
                .UsingEntity(j => j.ToTable("SubjectTeachers"));
        }
    }
}
