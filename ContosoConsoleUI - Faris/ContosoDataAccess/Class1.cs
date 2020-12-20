using System;
using ContosoModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ContosoDataAccess
{
    public class CourseStudentDataAccess
    {
        private string connectionString = "Data Source=ZENBOOK-UX303LA\MSSQLSERVER01;Initial Catalog=ContosoConsoloDB;Integrated Security=True";
        public bool SaveCourse(Course obj)
        {
            // Step 1 :- open the connection  ado.net, (active data objective)
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Step 2 :- Create SQL insert into
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblCourse(coursename) values('" + obj.name + "')";
            comm.Connection = conn;
            // Step 3 :- Execute query
            comm.ExecuteNonQuery(); // means i don't want to receive it but insert it
            // Step 4 :- Close connection 
            conn.Close();
            return true;
        }
        public bool SaveStudent(Student obj)
        {
            // Step 1 :- open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Step 2 :- Create SQL insert into.
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblstudent(studentname,studentmarks,courseid_fk) values('"
                                + obj.name + "'," + obj.marks + "," + obj.courseId + ")";
            comm.Connection = conn;
            // Step 3 :- Execute query
            comm.ExecuteNonQuery();
            // Step 4 :- Close connection 
            conn.Close();
            return true;
        }
        public int FindCourse(string courseName)
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Id from tblCourse where CourseName='" + courseName + "'"; //double quote for c# and single quote for sqlquery
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            dr.Read(); // go to first row and get the id
            int id = Convert.ToInt32(dr["id"]);
            conn.Close();
            return id;


        }
        public List<Course> getCourses()
        {
            // Create instances of courses
            List<Course> courses = new List<Course>();
            // Step 1 :- open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Step 2:: Create SQL insert into.
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select id,CourseName from tblCourse"; //sql not case sensitive
            comm.Connection = conn;
            //Step 3: Execute Reader and do the function reading
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course(); //create a course object 
                temp.id = Convert.ToInt32(dr["id"]); // extract id data from sql into object
                temp.name = dr["CourseName"].ToString(); // extract id data from sql filling into object
                courses.Add(temp); // add to list
            }

            //Step 4: Close connection
            conn.Close(); // always close first before do a return

            return courses; //return to UI
        }
    }
}
