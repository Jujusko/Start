using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Dinar.Categories
{
    public class CategoryInfo
    {
        public  int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }

        public string Date { get; set; }
        public double Sum { get; set; }
        public string NameCategory { get; set; }

        public CategoryInfo Next { get; set; }
        public CategoryInfo Prev { get; set; }

        public CategoryInfo(int day, int mounth, int year, int sum, string nameCat)
        {
            Date = $"{day}.{mounth}.{year}";
            Day = day;
            Mounth = mounth;
            Year = year;
            Sum = sum;
            NameCategory = nameCat;
        }
    }
}
