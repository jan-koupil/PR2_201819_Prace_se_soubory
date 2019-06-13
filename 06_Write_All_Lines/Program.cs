using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Write_All_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cílový adresář C:\Users\Public\TestFolder musí existovat

            string[] radky = { "První řádek", "Druhý řádek", "Třetí řádek" };
            // WriteAllLines vytvoří soubor, zapíše do něj pole/collection řetězců
            // a pak zavře. Není třeba Flush() resp. Close()
            // Pokud soubor existuje, bude přepsán
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteAllLines.txt", radky);
        }
    }
}
