using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.Start();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("The file containing account information could not be found.  Contact IT");
                Console.WriteLine("Press any key to quit the application...");
                Console.ReadKey();
            }
        }
    }
}
