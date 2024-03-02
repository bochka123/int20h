using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.HasKey(x => new {x.StudentId, x.LessonId});

            builder
                .HasOne(x => x.Student)
                .WithMany();

            builder.HasOne(x => x.Lesson)
                .WithMany();

        }
    }
}
