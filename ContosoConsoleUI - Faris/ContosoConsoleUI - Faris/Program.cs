using System;
using System.Collections.Generic;
using ContosoModel;
using System.Linq;
using ContosoDataAccess;

namespace ContosoConsoleUI___Faris
{
    class Program
    {
        #region declaration for course name
        //static Course course = new Course(); - move to the method below
        /* static List<Course> courses = new List<Course>(); - don't need store in list anymore
        cause storing in sql server*/
        #endregion

        #region declaration for students
        static Student student = new Student();
        static List<Student> students = new List<Student>();
        #endregion

        static char enter;

        static void Main(string[] args)
        {

            DisplayOptions();

            while (enter != '5')
            {
                if (enter == '1')
                {
                    AddNewCourse();
                }
                if (enter == '2')
                {
                    AddStudent();
                }
                if (enter == '4')
                {
                    DisplayOptionfour();
                }
                if (enter == '3')
                {
                    DisplayCourse();
                }
            }

        }

        static void AddStudent()
        {
            {
                Console.WriteLine("Enter the course name");
                string coursename = Console.ReadLine();
                CourseStudentDataAccess db = new CourseStudentDataAccess();
                int courseid = db.FindCourse(coursename);
                if (courseid == 0)
                {
                    Console.WriteLine("No such course exists");
                }
                else
                {
                    Student student = new Student();
                    Console.WriteLine("Enter student name");
                    student.name = Console.ReadLine();

                    Console.WriteLine("Enter student marks");
                    string marks = Console.ReadLine();
                    int markschecked = 0;
                    if (int.TryParse(marks, out markschecked) == true) // Try parse return
                    {
                        student.marks = markschecked;
                        student.courseId = courseid;
                        db.SaveStudent(student);
                    }
                    else
                    {
                        Console.WriteLine("Marks should be numeric");

                    }


                }
                Console.ReadLine();
            }

        }

        static void AddNewCourse()
        {
            {
                Course course = new Course();
                Console.WriteLine("Enter Course name");
                course.name = Console.ReadLine();
                // course.Add(Course); - remove to make the dataaccess call below
                CourseStudentDataAccess db = new CourseStudentDataAccess(); // create object of this
                db.SaveCourse(course);

                Console.ReadLine();
            }
        }

        static void DisplayOptions()
        {
            Console.WriteLine("Press (1) - Add a new course.");
            Console.WriteLine("Press (2) - Add student to course.");
            Console.WriteLine("Press (3) - Display all courses, total students, average marks");
            Console.WriteLine("Press (4) - Display all students : Student ID, Name, Marks");
            Console.WriteLine("Press (5) - To Exit");

            enter = Convert.ToChar(Console.ReadLine());
        }

        static void DisplayOptionfour()
        {
            foreach (Student attributes in students)
            {
                Console.WriteLine(attributes.id + " " + attributes.name);
            }
        }

        static void DisplayCourse()
        {
            CourseStudentDataAccess db = new CourseStudentDataAccess(); //create instances

            List<Course> courses = db.getCourses();

            foreach (var temp in courses) // coming from sql server
            {
                Console.WriteLine("Id :- " + temp.id
                            + " Course Name :- " + temp.name);
            }
            Console.ReadLine();
        }
    }
}
