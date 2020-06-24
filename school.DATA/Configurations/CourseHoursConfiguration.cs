using school.MODAL;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace school.DATA.Configurations
{
    public class CourseHoursConfiguration: IEntityTypeConfiguration<CourseHours>
    {
           public void Configure(EntityTypeBuilder<CourseHours> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);

            builder
                .Property(m => m.courseId)
                .IsRequired();
            builder
            .Property(m => m.StartDate)
            .IsRequired();
            builder
            .Property(m => m.EndDate)
            .IsRequired();
            builder
            .Property(m => m.days)
            .IsRequired();
            builder
            .Property(m => m.hours)
            .IsRequired();

          builder
              .ToTable("CourseHours");
        }
    }
}