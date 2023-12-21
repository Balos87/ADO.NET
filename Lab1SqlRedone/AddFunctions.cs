using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SqlRedone
{
    internal class AddFunctions
    {
        internal static void AddStudentsToDatabase(string connectionString)
        {
            Console.Write("\nFirst name: ");
            string firstNameInput = Console.ReadLine();

            Console.Write("\nLast name: ");
            string lastNameInput = Console.ReadLine();

            Console.WriteLine("\n1. Python\n2. Java\n3. .Net");
            Console.Write("\nCourse ID: ");
            string courseIdInput = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string addStudentsToDbQuery = "Insert Into Students (firstname, lastname, course_id) Values (@FirstName, @LastName, @CourseId)";

                SqlCommand command = new SqlCommand(addStudentsToDbQuery, connection);
                command.Parameters.AddWithValue("@FirstName", firstNameInput);
                command.Parameters.AddWithValue("@LastName", lastNameInput);
                command.Parameters.AddWithValue("@CourseId", courseIdInput);

                command.ExecuteNonQuery();
            }
        }

        internal static void AddStaffToDatabase(string connectionString)
        {
            Console.Write("\nFirst name: ");
            string firstNameInput = Console.ReadLine();

            Console.Write("\nLast name: ");
            string lastNameInput = Console.ReadLine();

            Console.WriteLine("\n1. Teacher\n2. Admin\n3. Principal");
            Console.Write("\nRole-ID: ");
            string roleIdInput = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string addStaffToDbQuery = "Insert Into Staffs (firstname, lastname, role_id) Values (@FirstName, @LastName, @RoleId)";

                SqlCommand command = new SqlCommand(addStaffToDbQuery, connection);
                command.Parameters.AddWithValue("@FirstName", firstNameInput);
                command.Parameters.AddWithValue("@LastName", lastNameInput);
                command.Parameters.AddWithValue("@RoleId", roleIdInput);

                command.ExecuteNonQuery();
            }
        }
    }
}
