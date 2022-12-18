using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

internal class InterviewMap : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.ToTable(nameof(Interview));

        builder.Property(x => x.Status).IsRequired().HasMaxLength(64);

        builder.HasOne<Interviewer>().WithMany(x => x.Interviews).HasForeignKey(x => x.InterviewerUserId);
        builder.HasOne<Interviewee>().WithMany(x => x.Interviews).HasForeignKey(x => x.IntervieweeUserId);
    }
}