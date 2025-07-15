using MySql.Data.MySqlClient;
//using MySqlConnector;
using System;

namespace NewProj
{
    internal class StudentController
    {
        private string connectionString = "Server=localhost;Database=Studentdemo;Uid=root;Pwd=deva57;";

        public void InsertStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO students (Id, Name, Dept, GPA) VALUES (@Id, @Name, @Dept, @gpa)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Dept", student.Dept);
                cmd.Parameters.AddWithValue("@gpa", student.GPA);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student inserted successfully.");
            }
        }

        public void GetStudent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM students WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}");
                        Console.WriteLine($"Name: {reader["Name"]}");
                        Console.WriteLine($"Dept: {reader["Dept"]}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE students SET Name = @Name, Dept = @Dept WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Dept", student.Dept);
                cmd.Parameters.AddWithValue("@gpa", student.GPA);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Student updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM students WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }
    }
}
