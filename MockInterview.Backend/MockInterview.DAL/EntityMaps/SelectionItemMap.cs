using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

internal class SelectionItemMap : IEntityTypeConfiguration<SelectionItem>
{
    public void Configure(EntityTypeBuilder<SelectionItem> builder)
    {
        builder.ToTable(nameof(SelectionItem));

        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.DisplayValue).IsRequired();
    }
}