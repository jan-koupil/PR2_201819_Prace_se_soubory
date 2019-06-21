using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ReadAll_as_String
{
    class Program
    {
        static void Main(string[] args)
        {
            // zavinac pred uvozovkou znamena doslovny retezec - neni treba escapovat \ apod.
            string path = @"C:\Users\Public\TestFolder\testfile.txt";
            string text = System.IO.File.ReadAllText(path);           
            Console.WriteLine("Obsah souboru {0} : {1}", path, text);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
