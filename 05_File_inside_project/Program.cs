using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_File_inside_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Soubor testfile.txt je nyní součástí projektu - vytvořeno přetažením
            // myší na explorer. Je třeba na něm nastavit "Copy to output"
            // a pak jej lze používat bez absolutní cesty

            string text = System.IO.File.ReadAllText(@"Files\testfile.txt");
            Console.WriteLine("Obsah souboru: {0}", text);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
