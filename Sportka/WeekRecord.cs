using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportka
{
    public class WeekRecord
    {
        public int Year { get; private set; }
        public int Week { get; private set; }
        public int[] Numbers1 { get; private set; }
        public int[] Numbers2 { get; private set; }

        public WeekRecord(string row)
        {
            string[] elements = row.Split(';');
            Year = int.Parse(elements[0]);
            Week = int.Parse(elements[1]);

            List<int> num1 = new List<int>();
            for (int i = 2; i < 9; i++)
            {
                int num = int.Parse(elements[i]);
                if (num > 0)
                    num1.Add(num);
            }
            Numbers1 = num1.ToArray();

            List<int> num2 = new List<int>();
            for (int i = 9; i < 16; i++)
            {
                int num = int.Parse(elements[i]);
                if (num > 0)
                    num2.Add(num);
            }
            Numbers2 = num2.ToArray();
        }
    }
}
