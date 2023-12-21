using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using Lab1SqlRedone;

namespace Labb1SQL
{
    internal class MenuHandler
    {
        public static void MenuFunction(string connectionToDatabase)
        {
            while (true)
            {
                Console.WriteLine("\nSimSchoolMenu:" +
                                  "\n1. Get all students on sorted list" +
                                  "\n2. Get staff function (all or specific roles)" +
                                  "\n3. Get students from specific course" +
                                  "\n4. Get all grades set the past month" +
                                  "\n5. Get grade scores (min, max or average)" +
                                  "\n6. Add student to database" +
                                  "\n7. Add staff to database" +
                                  "\n0. Exit program"
                                  );

                Console.Write("\r\nSelect an option: ");
                string MenuChoiceToSwitch = Console.ReadLine();

                switch (MenuChoiceToSwitch)
                {
                    case "1":
                        SimulationForEffect.SimFetchingData();
                        GetFunctions.GetAllStudentsByNameSortAndAscOrDesc(connectionToDatabase);
                        break;
                    case "2":
                        SimulationForEffect.SimFetchingData();
                        GetFunctions.GetStaffBasedOnIdOrAll(connectionToDatabase);
                        break;
                    case "3":
                        SimulationForEffect.SimFetchingData();
                        GetFunctions.GetStudentsFromSpecificClass(connectionToDatabase);
                        break;
                    case "4":
                        SimulationForEffect.SimFetchingData();
                        GetFunctions.GetGradesThatWasSetWithinLastMonth(connectionToDatabase);
                        break;
                    case "5":
                        SimulationForEffect.SimFetchingData();
                        GetFunctions.GetAverageGrades(connectionToDatabase);
                        break;
                    case "6":
                        SimulationForEffect.SimAboutToAddData();
                        AddFunctions.AddStudentsToDatabase(connectionToDatabase);
                        SimulationForEffect.SimAddingData();
                        break;
                    case "7":
                        SimulationForEffect.SimAboutToAddData();
                        AddFunctions.AddStaffToDatabase(connectionToDatabase);
                        SimulationForEffect.SimAddingData();
                        break;
                    case "0":
                        Console.WriteLine("Closing program...");
                        Thread.Sleep(2000);
                        return;
                    default:
                        Console.WriteLine("Bad input.");
                        break;
                }

                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
