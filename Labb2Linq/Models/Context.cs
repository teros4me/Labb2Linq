using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<SchoolClass> SchoolClasses { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<SchoolClassCourse> SchoolClassCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-9PE0LLE1\\SQLEXPRESS;Initial Catalog=Labb2LinqSchool;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedingData.SeedingStudents(modelBuilder);
            SeedingData.SeedingSchoolClasses(modelBuilder);
            SeedingData.SeedingCourses(modelBuilder);
            SeedingData.SeedingTeachers(modelBuilder);
            SeedingData.SeedingSchoolClassCourses(modelBuilder);
        }
    }
}
