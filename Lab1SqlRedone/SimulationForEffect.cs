using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1SqlRedone
{
    internal class SimulationForEffect
    {
        internal static void SimFetchingData()
        {
            Console.WriteLine("\nFetching data...");
            Thread.Sleep(1000);
            Console.WriteLine("Please wait...");
            Thread.Sleep(1000);
            Console.WriteLine("Success! Data is about to be presented.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        internal static void SimAboutToAddData()
        {
            Console.WriteLine("\nDatastorage function activated..");
            Thread.Sleep(1000);
            Console.Clear();
        }

        internal static void SimAddingData()
        {
            Console.Clear();
            Console.WriteLine("\nSaving Data...");
            Thread.Sleep(1000);
            Console.WriteLine("Please wait...");
            Thread.Sleep(1000);
            Console.WriteLine("Success! Data is saved.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
