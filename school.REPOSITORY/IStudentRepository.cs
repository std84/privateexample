using System.Collections.Generic;

using System;

using System.Linq.Expressions;
using System.Threading.Tasks;
using school.MODAL;
namespace school.REPOSITORY
{
    public interface IStudentRepository
    {
                Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<Object>> GetStudentByCourseAsync(int id);
          Task<Student> GetStudentById(int id);
        IEnumerable<Student> Find(Expression<Func<CourseStudentList, bool>> predicate);
         Task<bool> updateStudent(Student student);
         Task<bool> updateStudentPhoto(int courseId,string dbPath);
        Task AddAsync(Student entity);
        void Remove(Student entity);
        void RemoveRange(IEnumerable<Student> entities);
    }
}