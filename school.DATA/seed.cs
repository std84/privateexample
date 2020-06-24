using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using school.MODAL;


namespace school.DATA
{
    public class seed
    {
        private readonly dataContext _context;
        public seed(dataContext context){
            _context = context;
        }
        public void insertCourse(JToken courses){
            var user =courses.ToObject<List<Course>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                Course courseobj=course;

                _context.Course.Add(courseobj);
            }
            _context.SaveChanges();
        }
          public void insertStudent(JToken courses){
            var user =courses.ToObject<List<Student>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                Student courseobj=course;

                _context.Student.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertTeacher(JToken courses){
            var user =courses.ToObject<List<Teacher>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                Teacher courseobj=course;

                _context.Teacher.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertTeacherToCourse(JToken courses){
            var user =courses.ToObject<List<TeacherToCourse>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                TeacherToCourse courseobj=course;

                _context.TeacherToCourse.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertCourseHours(JToken courses){
            var user =courses.ToObject<List<CourseHours>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                CourseHours courseobj=course;

                _context.CourseHours.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertStudentToCourse(JToken courses){
            var user =courses.ToObject<List<StudentToCourse>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                StudentToCourse courseobj=course;

                _context.StudentToCourse.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertCourseAssigments(JToken courses){
            var user =courses.ToObject<List<CourseAssigments>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                CourseAssigments courseobj=course;

                _context.CourseAssigments.Add(courseobj);
            }
            _context.SaveChanges();
        }
        public void insertStudentAssigment(JToken courses){
            var user =courses.ToObject<List<StudentAssigment>>();// JObject.Parse(courses).DeserializeResponse<List<Course>>();
          //var users= JsonConvert.DeserializeObject<List<Course>>(courses);
            foreach( var course in user){
                StudentAssigment courseobj=course;

                _context.StudentAssigment.Add(courseobj);
            }
            _context.SaveChanges();
        }
         public void SeedDb(){

            var userData = System.IO.File.ReadAllText("../school.DATA/databas.json");
             
            var students= JObject.Parse(userData);// JsonConvert.DeserializeObject(userData); //JsonConvert.SerializeObject(userData);//JsonConvert.DeserializeObject(userData.);
            foreach (var obj in students)
            {
                var Course = obj;
                var test=Course.Key;
                switch (Course.Key)
                {
                    case "Course":
                        insertCourse(Course.Value);
                        break;
                    case "Student":
                        insertStudent(Course.Value);
                        break;
                    case "StudentToCourse":
                         insertStudentToCourse(Course.Value);
                        //Console.WriteLine("Case StudentToCourse");
                        break;
                    case "CourseAssigments":
                         insertCourseAssigments(Course.Value);
                        //Console.WriteLine("Case StudentToCourse");
                        break;
                    case "StudentAssigment":
                         insertStudentAssigment(Course.Value);
                        //Console.WriteLine("Case StudentToCourse");
                        break;
                    case "CourseHours":
                        insertCourseHours(Course.Value);
                       // Console.WriteLine("Case CourseHours");
                        break;
                    case "Teacher":
                        insertTeacher(Course.Value);
                       // Console.WriteLine("Case CourseHours");
                        break;
                    case "TeacherToCourse":
                        insertTeacherToCourse(Course.Value);
                       // Console.WriteLine("Case CourseHours");
                        break;
                        
                    default:
                       // Console.WriteLine("Default case");
                        break;
                }
                //Console.WriteLine(Course);
            }
           // var students= JsonConvert.DeserializeObject<List<Student>>(userData.);
           // foreach( var user in students){
                
               // _context.Student.Add(user);
           // }
           // _context.SaveChanges();
           string str="ss";
        }
    }
}