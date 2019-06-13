using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Write_All_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cílový adresář C:\Users\Public\TestFolder musí existovat

            string text = "U lednice dítě stálo, zplna hrdla křičelo...";
            // WriteAllText vytvoří soubor, zapíše do něj řetězec a pak jej zavře
            // Není třeba volat Flush() resp. Close(). Pokud soubor existuje, bude přepsán.
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteAllText.txt", text);
        }
    }
}
