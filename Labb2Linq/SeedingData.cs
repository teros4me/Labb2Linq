using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq
{
    public class SeedingData
    {
        public static void SeedingStudents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 1,
                StudentFirstName = "Anders",
                StudentLastName = "Pettersson",
                SchoolClassId = 1
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 2,
                StudentFirstName = "Peter",
                StudentLastName = "Karlsson",
                SchoolClassId = 1
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 3,
                StudentFirstName = "Lisa",
                StudentLastName = "Persson",
                SchoolClassId = 1
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 4,
                StudentFirstName = "Stina",
                StudentLastName = "Alexandersson",
                SchoolClassId = 1
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 5,
                StudentFirstName = "Fredrik",
                StudentLastName = "From",
                SchoolClassId = 1
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 6,
                StudentFirstName = "Anna",
                StudentLastName = "Persson",
                SchoolClassId = 2
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 7,
                StudentFirstName = "Åke",
                StudentLastName = "Stolt",
                SchoolClassId = 2
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 8,
                StudentFirstName = "Vera",
                StudentLastName = "Strömberg",
                SchoolClassId = 2
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 9,
                StudentFirstName = "Kim",
                StudentLastName = "Fredlund",
                SchoolClassId = 2
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 10,
                StudentFirstName = "Robin",
                StudentLastName = "Andersson",
                SchoolClassId = 2
            });
        }

        public static void SeedingSchoolClasses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>().HasData(new SchoolClass 
            {
                SchoolClassId = 1,
                SchoolClassName = "1a"
            });
            modelBuilder.Entity<SchoolClass>().HasData(new SchoolClass
            {
                SchoolClassId = 2,
                SchoolClassName = "1b"
            });
        }

        public static void SeedingCourses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 1,
                CourseName = "Programmering 1",
                TeacherId = 3
            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 2,
                CourseName = "Programmering 2",
                TeacherId = 2
            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 3,
                CourseName = "Engelska",
                TeacherId = 1
            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 4,
                CourseName = "Matematik",
                TeacherId = 1
            });
        }

        public static void SeedingTeachers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherId = 1,
                TeacherFirstName = "Maja",
                TeacherLastName = "Lundström"
            });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherId = 2,
                TeacherFirstName = "Anas",
                TeacherLastName = "Qlok"
            });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherId = 3,
                TeacherFirstName = "Reidar",
                TeacherLastName = "Qlok"
            });
        }

        public static void SeedingSchoolClassCourses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClassCourse>().HasData(new SchoolClassCourse
            {
                SchoolClassCourseId = 1,
                SchoolClassId = 1,
                CourseId = 1
            });
            modelBuilder.Entity<SchoolClassCourse>().HasData(new SchoolClassCourse
            {
                SchoolClassCourseId = 2,
                SchoolClassId = 2,
                CourseId = 2
            });
        }
    }
}
