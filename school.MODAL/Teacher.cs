using System.Collections.Generic;

namespace school.MODAL
{
    public class Teacher
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int teacherId { get; set; }
         public virtual  ICollection<Course> course { get; set; }
      //  public IEnumerable<Course>  course { get; set; }
        
    }
}