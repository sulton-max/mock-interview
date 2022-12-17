using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

public class TalentMap : IEntityTypeConfiguration<Talent>
{
    public void Configure(EntityTypeBuilder<Talent> builder)
    {
        builder.ToTable(nameof(Talent));
        
        builder.HasOne<User>().WithOne(x => x.Talent).HasForeignKey<User>(x => x.TalentId);
    }
}