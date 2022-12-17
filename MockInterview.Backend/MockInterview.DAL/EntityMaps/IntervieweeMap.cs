﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockInterview.Core.Models.Entities;

namespace MockInterview.DAL.EntityMaps;

public class IntervieweeMap : IEntityTypeConfiguration<Interviewee>
{
    public void Configure(EntityTypeBuilder<Interviewee> builder)
    {
        builder.ToTable(nameof(Interviewee));
    }
}