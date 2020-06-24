using System;
using Microsoft.AspNetCore.Http;

namespace school.MODAL
{
    public class CourseInfo
    {
          public int courseId { get; set; }
          public DateTime startDate { get; set; }
          public DateTime endDate { get; set; }
          public string days { get; set; }
          public string image { get; set; }
       
          public string hours { get; set; }
          public string courseName { get; set; }
          public string description { get; set; }
          public string teacherName { get; set; }
          public byte[] courseImage{ get; set; }
    }
}