
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school.MODAL;
namespace school.DATA.Configurations
{
    public class StudentAssigmentConfiguration: IEntityTypeConfiguration<StudentAssigment>
    {
        public void Configure(EntityTypeBuilder<StudentAssigment> builder)
        {
            builder
                .HasKey(a => a.id);

            builder
                .Property(m => m.id);
            builder
                .Property(m => m.grade)
                .IsRequired();
            builder
                .Property(m => m.precentage)
                .IsRequired();

            builder
                .Property(m => m.studentid)
                .IsRequired();
            builder
                .Property(m => m.assigmentid)
                .IsRequired();


           builder
             .ToTable("StudentAssigment");
        }
    }
}