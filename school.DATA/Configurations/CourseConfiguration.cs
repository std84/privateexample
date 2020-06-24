
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school.MODAL;

namespace school.DATA.Configurations
{
    public class CourseConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);
            builder
                .Property(m => m.courseId)
                .IsRequired();
            builder
                .Property(m => m.name)
                .IsRequired()
                .HasMaxLength(50);
            builder
            .Property(m => m.image)
            .IsRequired();
           builder
                .Property(m => m.teacherId)
                .IsRequired();
            builder
            .Property(m => m.description)
            .HasMaxLength(100);


           builder
             .ToTable("Course");
        }
    }
}