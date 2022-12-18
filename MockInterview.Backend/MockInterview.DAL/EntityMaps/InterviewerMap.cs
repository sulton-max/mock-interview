using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

internal class InterviewerMap : IEntityTypeConfiguration<Interviewer>
{
    public void Configure(EntityTypeBuilder<Interviewer> builder)
    {
        builder.ToTable(nameof(Interviewer));
    }
}