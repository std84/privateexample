using System.Collections.Generic;

namespace school.MODAL
{
    public class Course
    {
         public int id { get; set; }
        public int courseId { get; set; }
         public int teacherId { get; set; }
          
        public string name { get; set; }
        public string description { get; set; }
       public string image { get; set; }
       
        public virtual  ICollection<CourseHours> courseTime{ get; set; }
       
    }
}