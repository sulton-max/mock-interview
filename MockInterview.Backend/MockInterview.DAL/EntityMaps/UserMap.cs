using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

internal class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.Password).IsRequired();

        builder.HasOne<Interviewer>().WithOne(x => x.User).HasForeignKey<Interviewer>(x => x.UserId);
        builder.HasOne<UserRole>().WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}