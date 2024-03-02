using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(q => q.QuestionOptions)
                .WithOne(q => q.Question)
                .HasForeignKey(q => q.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
