
using school.MODAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace school.DATA.Configurations
{
    public class TeacherToCourseConfiguration: IEntityTypeConfiguration<TeacherToCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherToCourse> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);
            builder
                .Property(m => m.teacherId)
                .IsRequired();
            builder
                .Property(m => m.courseId)
                .IsRequired();
            builder
              .ToTable("TeacherToCourse");

        }
    }
}