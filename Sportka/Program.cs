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

            int[] common = CommonNumbers(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 3, 5, 7, 9, 11 });
            Console.WriteLine(string.Join(",", common));
            Console.ReadKey();
            return;

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

        static int[] CommonNumbers(int[] nums1, int[] nums2)
        {
            //List<int> result = new List<int>();
            //foreach (int n1 in nums1)
            //{
            //    foreach (int n2 in nums2)
            //    {
            //        if (n2 == n1 && !result.Contains(n1))
            //        {
            //            result.Add(n1);
            //        }

            //    }
            //}
            //foreach (int n2 in nums2)
            //{
            //    foreach (int n1 in nums1)
            //    {
            //        if (n2 == n1 && !result.Contains(n1))
            //        {
            //            result.Add(n1);
            //        }

            //    }
            //}

            //return result.ToArray();
            
            return nums1.Intersect(nums2).ToArray();
        }
    }
}
