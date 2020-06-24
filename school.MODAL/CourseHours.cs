using System;

namespace school.MODAL
{
    public class CourseHours
    {
          public int id { get; set; }
          public int courseId { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public string days { get; set; }
          public string hours { get; set; }
     
    }
}