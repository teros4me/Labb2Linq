using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class SchoolClassCourse
    {
        [Key]
        public int SchoolClassCourseId { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}