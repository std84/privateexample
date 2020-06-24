
using school.MODAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;


namespace school.DATA.Configurations
{
    public class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);

            builder
                .Property(m => m.name)
                .IsRequired()
                .HasMaxLength(50);
            builder
            .Property(m => m.email)
            .IsRequired()
            .HasMaxLength(50);
  
            builder
            .Property(m => m.password)
            .IsRequired()
            .HasMaxLength(10);
                      builder
                .Property(m => m.teacherId)
                .IsRequired();
               builder
              .ToTable("Teacher");

        }
    }
}