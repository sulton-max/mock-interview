using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

internal class TalentMap : IEntityTypeConfiguration<Talent>
{
    public void Configure(EntityTypeBuilder<Talent> builder)
    {
        builder.ToTable(nameof(Talent));

        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.Projects).IsRequired();
        
        builder.HasOne<User>().WithOne(x => x.Talent).HasForeignKey<User>(x => x.TalentId);
    }
}