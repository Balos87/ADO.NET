using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SqlRedone
{
    internal class GetFunctions
    {
        internal static void GetAllStudentsByNameSortAndAscOrDesc(string connectionString)
        {
            Console.WriteLine("Sort on first or lastname:\n1. First Name\n2. Last Name");
            Console.Write("\nInput: ");
            string nameSortingInput = Console.ReadLine();

            Console.WriteLine("List it by ascending or decending:\n1. Ascending\n2. Decending");
            Console.Write("\nInput: ");
            string ascendingOrDecendingInput = Console.ReadLine();

            string nameSortingHandlerToQuery;
            string ascOrDecHandlerToQuery;

            if (nameSortingInput == "1")
            {
                nameSortingHandlerToQuery = "firstname";
            }
            else
            {
                nameSortingHandlerToQuery = "lastname";
            }

            if (ascendingOrDecendingInput == "1")
            {
                ascOrDecHandlerToQuery = "Asc";
            }
            else
            {
                ascOrDecHandlerToQuery = "Desc";
            }

            string studentNameAndOrderQuery = $"Select firstname, lastname From Students Order By {nameSortingHandlerToQuery} {ascOrDecHandlerToQuery}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(studentNameAndOrderQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["firstname"]} {reader["lastname"]}");
                    }
                }
            }
        }

        internal static void GetStudentsFromSpecificClass(string connectionString)
        {
            Console.WriteLine("1. Python\n2. Java\n3. .Net");
            Console.Write("\nEnter ID: ");
            string inputForCourseId = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string findStudentsInSpecificCourseQuery = $"Select firstname, lastname From Students Where course_id = {inputForCourseId}";
                SqlCommand command = new SqlCommand(findStudentsInSpecificCourseQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["firstname"]} {reader["lastname"]}");
                    }
                }
            }
        }

        internal static void GetStaffBasedOnIdOrAll (string connectionString)
        {
            Console.WriteLine("1. Teacher\n2. Admin\n3. Principal");
            Console.WriteLine("Type ID or all.");
            Console.Write("Input: ");
            string idOrAllInput = Console.ReadLine();

            string getStaffByIdOrAllQuery;
            if (idOrAllInput.ToLower() == "all")
            {
                getStaffByIdOrAllQuery = "Select firstname, lastname, role_name From Staffs Join StaffRoles On Staffs.role_id = StaffRoles.role_id";
            }
            else
            {
                getStaffByIdOrAllQuery = $"Select firstname, lastname, role_name From Staffs Join StaffRoles On Staffs.role_id = StaffRoles.role_id Where StaffRoles.role_id = {idOrAllInput}";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(getStaffByIdOrAllQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (idOrAllInput.ToLower() == "all")
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["firstname"]} {reader["lastname"]}, Role: {reader["role_name"]}");
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["firstname"]} {reader["lastname"]}, Role: {reader["role_name"]}");
                        }
                    }
                }
            }
        }

        internal static void GetGradesThatWasSetWithinLastMonth(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getAllGradesQuery = @"Select Students.firstname, Students.lastname, Courses.course_name, Grades.grade From Grades 
                                             Join Students On Grades.student_id = Students.student_id 
                                             Join Courses On Grades.course_id = Courses.course_id Where 
                                             Grades.date_when_set >= DateAdd(Month, -1, GetDate())";

                SqlCommand command = new SqlCommand(getAllGradesQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["firstname"]} {reader["lastname"]}, Course: {reader["course_name"]}, Grade: {reader["grade"]}");
                    }
                }
            }
        }

        internal static void GetAverageGrades(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string averageMinMaxGradesQuery = @"Select Courses.course_name, 
                                                    Avg(Grades.grade) As Average, Max(Grades.grade) As Highest, 
                                                    Min(Grades.grade) As Minimum From Grades 
                                                    Join Courses On Grades.course_id = Courses.course_id Group By Courses.course_name";

                SqlCommand command = new SqlCommand(averageMinMaxGradesQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Course: {reader["course_name"]}, Average score: {reader["Average"]}, " +
                                          $"Highest score: {reader["Highest"]}, Smallest score: {reader["Minimum"]}");
                    }
                }
            }
        }
    }
}
