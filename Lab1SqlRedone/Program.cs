using Labb1SQL;
using System.Data.SqlClient;

namespace Lab1SqlRedone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionToDatabase = @"Data Source=(localdb)\.;Initial Catalog=SimSchool;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionToDatabase))
            {
                connection.Open();
                MenuHandler.MenuFunction(connectionToDatabase);
            }
        }
    }


}
