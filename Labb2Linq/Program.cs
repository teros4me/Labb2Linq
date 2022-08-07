using System;
using System.Linq;

namespace Labb2Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            // Menyalternati

            Console.WriteLine("Välkommen! Välj en siffra i menyn:\n" +
                "1 - Visa alla lärare som undervisar i programmering 1\n" +
                "2 - Visa alla elever med deras lärare\n" +
                "3 - Visa alla elever som läser programmering 1 samt vilka lärare de har i den kursen\n" +
                "4 - Editera ett ämne från programmering 2 till OOP\n" +
                "5 - Uppdatera en elevs lärare i programmering 1 från Anas till Reidar");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    MenuGetTeachers(context); 
                    break;
                case 2:
                    MenuGetStudents(context); 
                    break;
                case 3:
                    MenuGetStudentsProg(context);
                    break;
                case 4:
                    MenuEditCourse(context);
                    break;
                case 5:
                    MenuEditProgTeacher(context);
                    break;
                default: 
                    Console.WriteLine("Välj en siffra mellan 1 och 5"); 
                    break;
            }

            // Menyval 1 - Visa alla lärare som undervisar i programmering 1
            static void MenuGetTeachers(Context context)
            {
                var progTeacher = from teach in context.Teachers
                                  join course in context.Courses on teach.TeacherId equals course.TeacherId
                                  where course.CourseName == "Programmering 1"
                                  select teach;
                foreach (var item in progTeacher)
                {
                    Console.WriteLine("Lärare: " + item.TeacherFirstName + " " + item.TeacherLastName);
                }

            }

            // Menyval 2 - Visa alla elever med deras lärare
            static void MenuGetStudents(Context context)
            {
                var studTeacher = from clas in context.SchoolClasses
                                  join stud in context.Students on clas.SchoolClassId equals stud.SchoolClassId
                                  join clasc in context.SchoolClassCourses on clas.SchoolClassId equals clasc.SchoolClassId
                                  join cour in context.Courses on clasc.CourseId equals cour.CourseId
                                  join teach in context.Teachers on cour.TeacherId equals teach.TeacherId
                                  where clasc.SchoolClassId == stud.SchoolClassId && clasc.CourseId == cour.CourseId && cour.TeacherId == teach.TeacherId
                                  select new
                                  {
                                      stud, teach
                                  };
                foreach (var item in studTeacher)
                {
                    Console.WriteLine("Student: " + item.stud.StudentFirstName + " " + item.stud.StudentLastName + "\nTeacher: " + item.teach.TeacherFirstName + " " + item.teach.TeacherLastName + "\n");
                }
            }

            // Menyval 3 - Visa alla elever som läser programmering 1 samt vilka lärare de har i den kursen
            static void MenuGetStudentsProg(Context context)
            {
                var studProg = from clas in context.SchoolClasses
                               join stud in context.Students on clas.SchoolClassId equals stud.SchoolClassId
                               join clasc in context.SchoolClassCourses on clas.SchoolClassId equals clasc.SchoolClassId
                               join cour in context.Courses on clasc.CourseId equals cour.CourseId
                               join teach in context.Teachers on cour.TeacherId equals teach.TeacherId
                               where clasc.SchoolClassId == stud.SchoolClassId && clasc.CourseId == cour.CourseId && cour.TeacherId == teach.TeacherId && cour.CourseName == "Programmering 1"
                               select new
                               {
                                   stud,
                                   teach
                               };
                foreach (var item in studProg)
                {
                    Console.WriteLine("Student: " + item.stud.StudentFirstName + " " + item.stud.StudentLastName + "\nTeacher: " + item.teach.TeacherFirstName + " " + item.teach.TeacherLastName + "\n");
                }
            }

            // Menyval 4 - Editera ett ämne från programmering 2 till OOP
            static void MenuEditCourse(Context context)
            {
                var editCourse = from course in context.Courses
                                 where course.CourseName == "Programmering 2"
                                 select course;
                foreach (var item in editCourse)
                {
                    item.CourseName = "Objekt Orienterad Programmering";
                }
                context.SaveChanges();
            }

            // Menyval 5 - Uppdatera en elevs lärare i programmering 1 från Anas till Reidar
            static void MenuEditProgTeacher(Context context)
            {
                var editTeacher = from teach in context.Teachers
                                  join cour in context.Courses on teach.TeacherId equals cour.TeacherId
                                  where cour.CourseName == "Programmering 1"
                                  select cour;

                foreach (var item in editTeacher)
                {
                    item.TeacherId = 2;
                }
                context.SaveChanges();
            }
        }
    }
}
