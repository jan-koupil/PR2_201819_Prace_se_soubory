using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04_Streamreader_a_Using__Disposable_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Public\TestFolder\testfile.txt";

            // pozor, lze jen díky using System.IO, jinak System.IO.Streamreader
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            } // díky using nedělám File.Close() - je to disposable
            Console.ReadKey();
        }
    }
}
