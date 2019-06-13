using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Pouziti_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line; //musím deklarovat už zde

            string path = @"C:\Users\Public\TestFolder\testfile.txt";

            System.IO.StreamReader file = new System.IO.StreamReader(path);

            // zásadní! - návratová hodnota ReadLine() se uloží a dál porovnává
            // tzn. "čti, dokud je co číst"
            while ( (line = file.ReadLine()) != null ) 
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();
        }
    }
}
