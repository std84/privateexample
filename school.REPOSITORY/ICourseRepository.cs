using System.Collections.Generic;

using System;

using System.Linq.Expressions;
using System.Threading.Tasks;
using school.MODAL;

namespace school.REPOSITORY
{
    
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<IEnumerable<Object>> GetStudentByCourseAsync(int id);
        Task<CourseInfo> GetCourseByIdAsync(int id);
        Task<bool> UpdateCourse(CourseInfo course);
        Task<bool> updateCoursePhoto(int courseId,string dbPath);
        Task<IEnumerable<Object>> GetCourseAssigments(int id);
        Task<bool> SaveAll();
        IEnumerable<Course> Find(Expression<Func<CourseStudentList, bool>> predicate);
        
        Task AddAsync(Course entity);
        void Remove(Course entity);
        void RemoveRange(IEnumerable<Course> entities);
    }
}