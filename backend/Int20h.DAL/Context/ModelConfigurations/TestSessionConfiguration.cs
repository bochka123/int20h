using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Int20h.DAL.Context.ModelConfigurations
{
    public class TestSessionConfiguration : IEntityTypeConfiguration<TestSession>
    {
        public void Configure(EntityTypeBuilder<TestSession> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Test)
                .WithMany();

            builder.HasMany(x => x.Answers)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
