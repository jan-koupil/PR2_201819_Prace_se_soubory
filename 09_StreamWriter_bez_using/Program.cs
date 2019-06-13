using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_StreamWriter_bez_using
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] radky = { "První řádek", "Druhý řádek", "Třetí řádek", "Čtvrtý řádek", "Pátý řádek" };
            // Zapíšeme řádky do souboru

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\StreamWriterBezUsing.txt");

            foreach (string radek in radky)
            {

                file.WriteLine(radek);

            }

            Console.WriteLine("Soubor ještě není uzavřen! Stiskněte ENTER.");
            Console.ReadLine();
            file.Close();
            Console.WriteLine("Nyní je soubor uzavřen a mohou ho měnit jiné aplikace. Stiskněte ENTER");
            Console.ReadLine();

        }
    }

}
