
using Microsoft.EntityFrameworkCore;

using school.Data.Configurations;
using school.DATA.Configurations;
using school.MODAL;

namespace school.DATA
{
    public class dataContext: DbContext
    {
         public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
         public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentToCourse> StudentToCourse { get; set; }
         public DbSet<CourseHours> CourseHours { get; set; }
           public DbSet<TeacherToCourse> TeacherToCourse { get; set; }
        public DbSet<CourseAssigments> CourseAssigments { get; set; }
        public DbSet<StudentAssigment> StudentAssigment { get; set; }
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder
              .ApplyConfiguration(new StudentConfiguration());

            builder
              .ApplyConfiguration(new CourseConfiguration());
           builder
              .ApplyConfiguration(new StudentToCourseConfiguration());
            builder
              .ApplyConfiguration(new CourseHoursConfiguration());
            builder
              .ApplyConfiguration(new TeacherConfiguration());
            builder
              .ApplyConfiguration(new TeacherToCourseConfiguration());
            builder
              .ApplyConfiguration(new StudentAssigmentConfiguration());
            builder
              .ApplyConfiguration(new CourseAssigmentsConfiguration());

        }
    }
}