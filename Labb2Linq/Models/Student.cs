using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2Linq.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public int SchoolClassId { get; set; }

        public SchoolClass SchoolClass { get; set; }
    }
}

