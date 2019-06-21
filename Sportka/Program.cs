using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sportka
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYear = ReadInt("Zadej počáteční rok");
            int startWk = ReadInt("Zadej počáteční týden v roce");
            int endYear = ReadInt("Zadej konečný rok");
            int endWk = ReadInt("Zadej konečný týden v roce");

            if (endYear < startYear || (endYear == startYear && endWk < startWk))
            {
                Console.WriteLine("Nelze skončit dřív než začít.");
                return;
            }

            Console.WriteLine("Nejčastějším číslem bylo :" + MostFrequent(@"data\sportka-data.txt", startYear, startWk, endYear, endWk));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int ReadInt(string message)
        {
            Console.Write(message + ": ");
            int output;
            while (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.WriteLine("Zadej celé číslo");
                Console.Write(message + ": ");
            }
            return output;
        }

        static int MostFrequent(string filePath, int startYear, int startWk, int endYear, int endWk)
        {
            int[] counts = new int[50];
            for (int i = 0; i < 50; i++)
            {
                counts[i] = 0;
            }

            using (StreamReader sr = File.OpenText(filePath))
            {
                sr.ReadLine(); //zahodím první řádek - neuložím data
                string row = "";

                while ((row = sr.ReadLine()) != null)
                {
                    try
                    {
                        WeekRecord weekInfo = new WeekRecord(row);
                        if (
                             ( weekInfo.Year > startYear || (weekInfo.Year == startYear && weekInfo.Week >= startWk) )
                             && (weekInfo.Year < endYear || (weekInfo.Year == endYear && weekInfo.Week <= endWk))
                            )
                        {
                            foreach(int num in weekInfo.Numbers1)
                            {
                                counts[num]++;
                            }
                        }
                    }
                    catch
                    {
                        continue; //přeskoč chybné řádky
                    }
                }
            } // díky using nedělám File.Close() - je to disposable

            int max = 0;
            int mostFreq = 0;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    mostFreq = i;
                }
            }

            return mostFreq;
        }
    }
}
