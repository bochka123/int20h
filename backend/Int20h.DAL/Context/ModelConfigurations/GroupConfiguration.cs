using Int20h.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Int20h.DAL.Context.ModelConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);
        //builder
        //    .HasMany(g => g.Students)
        //    .WithOne(s => s.UserId)
        //    .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(g => g.Mentor)
            .WithMany(m => m.MentorGroups)
            .HasForeignKey(g => g.MentorId);
    }
}
