using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SchoolService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in both code and config file together.
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student)
        {
            string cs = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SPAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterFName = new SqlParameter
                {
                    ParameterName = "FirtstName",
                    Value = student.FirtstName
                };
                cmd.Parameters.Add(parameterFName);
                SqlParameter parameterLName = new SqlParameter
                {
                    ParameterName = "LastName",
                    Value = student.LastName
                };
                cmd.Parameters.Add(parameterLName);
                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "Email",
                    Value = student.Email
                };
                cmd.Parameters.Add(parameterEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditStudent(Student student)
        {
            string cs = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SPEditStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterFName = new SqlParameter
                {
                    ParameterName = "FirtstName",
                    Value = student.FirtstName
                };
                cmd.Parameters.Add(parameterFName);
                SqlParameter parameterLName = new SqlParameter
                {
                    ParameterName = "LastName",
                    Value = student.LastName
                };
                cmd.Parameters.Add(parameterLName);
                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "Email",
                    Value = student.Email
                };
                cmd.Parameters.Add(parameterEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();
            string cs = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SPGetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.FirtstName = reader["FirtstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    students.Add(student);
                }
            }
            return students;
        }
    }
}
