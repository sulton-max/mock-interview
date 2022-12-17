using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

public class ContactMap : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable(nameof(Contact));
        
        builder.HasOne<User>().WithOne(x => x.Contact).HasForeignKey<User>(x => x.ContactId);
    }
}