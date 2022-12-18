using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
             builder.ToTable(nameof(UserRole));
        
             builder.Property(x => x.DateCreated).IsRequired();
             builder.Property(x => x.DateLastModified).IsRequired();
             builder.Property(x => x.UpdatedByUserId);
        }
    }
}
