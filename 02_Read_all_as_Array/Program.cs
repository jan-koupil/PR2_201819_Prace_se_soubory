using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Read_all_as_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Public\TestFolder\testfile.txt";

            string[] lines = System.IO.File.ReadAllLines(path);

            Console.WriteLine("Contents of testfile.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
