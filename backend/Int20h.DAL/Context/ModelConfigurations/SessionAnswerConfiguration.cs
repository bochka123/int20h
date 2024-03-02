using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Int20h.DAL.Context.ModelConfigurations
{
    internal class SessionAnswerConfiguration : IEntityTypeConfiguration<SessionAnswer>
    {
        public void Configure(EntityTypeBuilder<SessionAnswer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Answer)
                .WithOne();

            builder.HasOne(x => x.Session)
                .WithMany(s => s.Answers)
                .HasForeignKey(x => x.SessionId);
        }
    }
}
