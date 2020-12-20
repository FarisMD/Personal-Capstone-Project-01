using System;
using System.Collections.Generic;
using System.Text;
using ContosoModel;

//Note to self: Need to read on class and objects. Self confusion is great. 
namespace ContosoModel
{
    public abstract class BaseModel
    {
        public virtual int id { get; set; }

        public abstract bool Validate(); // hlf defined

    }

    public class Course : BaseModel // inheritance
    {
        public Course()
        {

        }
        private string _name; // variables

        public string name
        {
            get { return _name; }
            set
            {
                // logic
                _name = value;



            }
        }

        // Aggregatio , using
        public List<Student> students { get; set; } = new List<Student>();

        public double CalculateAverage()
        {
            if (students.Count == 0) { return 0; } // to avoid divide by zero exceptio
            int runningtotal = 0;
            foreach (Student stud in students)
            {
                runningtotal = stud.marks + runningtotal;
            }
            return (runningtotal / students.Count);
        }

        public override bool Validate()
        {
            if (name.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class Student : BaseModel
    {



        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _marks;

        public int marks
        {
            get { return _marks; }
            set
            {
                if (value > 100) // per data input
                {

                    throw new Exception("Makrs can not be...");
                }
                _marks = value;
            }
        }

        private string _courseName;

        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public override bool Validate() // one go
        {
            if (courseName.Length == 0)
            {
                return false;
            }
            if (_marks > 100)
            {
                return false;
            }
            return true;
        }

        public int courseId { get; set; }
    }
}
