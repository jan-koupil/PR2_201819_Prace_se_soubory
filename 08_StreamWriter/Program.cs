using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] radky = { "První řádek", "Druhý řádek", "Třetí řádek", "Čtvrtý řádek", "Pátý řádek" };
            // Zapíšeme jen některé řádky do souboru
            // použití příkazu using automaticky zapíše stream a uzavře soubor, pak 
            // zavolá IDisposable.Dispose na objekt streamu
            // Poznámka: není vhodné používat pro textové soubory FileStream, StreamWriter,
            // protože kóduje výstup jako text, nikoli jako jednotlivé byte
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\StreamWriter.txt"))
            {
                // Zapíšeme jen sudé řádky.
                for (int i = 0; i < radky.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        file.WriteLine(radky[i]);
                    }
                }

                // Zapíšeme řádky, které neobsahují slovo "Druhý"
                //foreach (string radek in radky)
                //{
                //    if (!radek.Contains("Druhý"))
                //    {
                //        file.WriteLine(radek);
                //    }
                //}

            }

            // Do existujícího textového souboru lze na konec text připsat.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\StreamWriter.txt", true))
            {
                file.WriteLine("To nejlepší na konec");
            }
        }
    }
}
