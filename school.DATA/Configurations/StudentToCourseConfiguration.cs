using school.MODAL;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace school.Data.Configurations
{
    public class StudentToCourseConfiguration : IEntityTypeConfiguration<StudentToCourse>
    {
        public void Configure(EntityTypeBuilder<StudentToCourse> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);

            builder
                .Property(m => m.courseId)
                .IsRequired();
            builder
            .Property(m => m.studentId)
            .IsRequired();

  
          builder
              .ToTable("StudentToCourse");
        }
    }
}
