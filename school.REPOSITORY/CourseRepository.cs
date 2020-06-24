using System;
using System.Linq;

using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using school.DATA;
using school.MODAL;
using AutoMapper;

namespace school.REPOSITORY
{
    public class CourseRepository: ICourseRepository
    {
            private readonly IMapper _mapper;
           dataContext _courseprDbContext;
        public CourseRepository(IMapper mapper, dataContext courseprDbContext)
        {

            _courseprDbContext = courseprDbContext;
        }
        public async Task AddAsync(Course entity)
        {
            await _courseprDbContext.AddAsync(entity);
        }

        public async Task<bool> SaveAll()
        {
           return await _courseprDbContext.SaveChangesAsync() > 0;
        }


        public IEnumerable<Course> Find(Expression<Func<CourseStudentList, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> updateCoursePhoto(int courseId,string dbPath){
               var dbcoursetwo = await _courseprDbContext.Course
                .Where(m => m.courseId == courseId )
                .FirstOrDefaultAsync();
            
            dbcoursetwo.image = dbPath;
           
          
            return await _courseprDbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCourse(CourseInfo chcourse){
          
            Course dbcoursetwo = await _courseprDbContext.Course
                .Include( u => u.courseTime)
                .Where(m => m.courseId == chcourse.courseId )
                .FirstOrDefaultAsync();
            var originalItem = dbcoursetwo.courseTime.SingleOrDefault(i=>i.courseId == dbcoursetwo.id);
            //if(originalItem == null)
                //return false;
            
            dbcoursetwo.courseId = chcourse.courseId;
            originalItem.StartDate = chcourse.startDate;
            originalItem.EndDate = chcourse.endDate;
            originalItem.days = chcourse.days;
            originalItem.hours = chcourse.hours;
            dbcoursetwo.courseId = chcourse.courseId;
           // dbcoursetwo.teacherId = chcourse.courseId;
            dbcoursetwo.name = chcourse.courseName;
            dbcoursetwo.description = chcourse.description;
            dbcoursetwo.image = chcourse.image;
          
            return await _courseprDbContext.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseprDbContext.Set<Course>().Include(p => p.courseTime).ToListAsync();
        }
        public async Task<IEnumerable<Object>> GetCourseAssigments(int id){

            var resaulttest = await (from courseas in _courseprDbContext.CourseAssigments 
                          
                          where courseas.courseId == id
                          select courseas
                          ).ToListAsync();
          
 
            return resaulttest;
        }
        public async Task<CourseInfo> GetCourseByIdAsync(int id){
          
            var resaulttestgg = await (from course in _courseprDbContext.Course 
                join courseHours in _courseprDbContext.CourseHours on course.id  equals courseHours.courseId  into joinTable2
                from co in joinTable2.DefaultIfEmpty()
                join techersids in _courseprDbContext.TeacherToCourse on course.courseId  equals techersids.courseId  into joinTable3
                from teid in joinTable3.DefaultIfEmpty()
                join techers in _courseprDbContext.Teacher on teid.teacherId  equals techers.id  into joinTable4
                from te in joinTable4.DefaultIfEmpty()
                where course.courseId == id
                select new CourseInfo{courseId = course.courseId,
                                 startDate = co.StartDate ,endDate = co.EndDate ,days = co.days 
                                ,hours = co.hours ,courseName = course.name ,description = course.description
                                 ,teacherName = te.name, image = course.image 
                }
            ).ToListAsync();
               
 
            return resaulttestgg[0] ;
        }
        public async  Task<IEnumerable<Object>> GetStudentByCourseAsync(int id)
        {
            var resault = await (from course in _courseprDbContext.Course
                          join coursestudent in _courseprDbContext.StudentToCourse on course.id equals coursestudent.courseId
                          join student in _courseprDbContext.Student on coursestudent.studentId equals student.id into joinTable2
                          from co in joinTable2.DefaultIfEmpty()
                          where course.courseId == id
                          select new { courseName = course.name, studentName = co.name }
                          ).ToListAsync();
            var resaulttest = await (from coursestudent in _courseprDbContext.StudentToCourse 
                          join student in _courseprDbContext.Student on coursestudent.studentId equals student.id into joinTable2
                          from co in joinTable2.DefaultIfEmpty()
                          where coursestudent.courseId == id
                          select new { studentName = co.name, email = co.email }
                          ).ToListAsync();
          
 
            return resaulttest;
        }


        public void Remove(Course entity)
        {
            throw new NotImplementedException();
        }



        public void RemoveRange(IEnumerable<Course> entities)
        {
            throw new NotImplementedException();
        }

    

}
}