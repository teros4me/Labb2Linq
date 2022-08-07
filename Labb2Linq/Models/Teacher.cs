using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2Linq.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
