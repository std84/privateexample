using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using school.DATA;
using school.MODAL;
using System.Linq;

namespace school.REPOSITORY
{
    public class StudentRepository : IStudentRepository
    {
           dataContext _courseprDbContext;
        public   StudentRepository(dataContext courseprDbContext)
        {

            _courseprDbContext = courseprDbContext;
        }
        public async Task AddAsync(Student entity)
        {
            await _courseprDbContext.AddAsync(entity);
        }

        public IEnumerable<Student> Find(Expression<Func<CourseStudentList, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
           return await _courseprDbContext.Set<Student>().ToListAsync();
        }
        public async Task<Student> GetStudentById(int id){
                
          Student dbcoursetwo = await _courseprDbContext.Student
                .Where(m => m.id == id )
                .FirstOrDefaultAsync();
   //Entities dbo = new Entities();


            return dbcoursetwo;
        }
        public async Task<bool> updateStudent(Student student){
             Student dbcoursetwo = await _courseprDbContext.Student
                .Where(m => m.id == student.id )
                .FirstOrDefaultAsync();
           //if(originalItem == null)
                //return false;
            
            dbcoursetwo.id = student.id;
            
           // dbcoursetwo.teacherId = chcourse.courseId;
            dbcoursetwo.name = student.name;
            dbcoursetwo.email = student.email;
            dbcoursetwo.image = student.image;
            dbcoursetwo.password = student.password;
        
          
            return await _courseprDbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> updateStudentPhoto(int courseId, string dbPath){
               var dbcoursetwo = await _courseprDbContext.Student
                .Where(m => m.id == courseId )
                .FirstOrDefaultAsync();
            
            dbcoursetwo.image = dbPath;
           
          
            return await _courseprDbContext.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<object>> GetStudentByCourseAsync(int id)
        {
                 var resaulttest = await (from coursestudent in _courseprDbContext.StudentToCourse 
                          join Course in _courseprDbContext.Course on coursestudent.courseId equals Course.courseId into joinTable2
                          from co in joinTable2.DefaultIfEmpty()
                          where coursestudent.studentId == id
                          select new { courseName = co.name }
                          ).ToListAsync();
          
   //Entities dbo = new Entities();


            return resaulttest;
        }

        public void Remove(Student entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            throw new NotImplementedException();
        }

    
    }
}