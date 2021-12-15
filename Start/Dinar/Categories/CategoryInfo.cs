using System.Collections.Generic;

namespace Start.Dinar.Categories
{
    public class CategoryInfo
    {
        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }

        public string Date { get; set; }
        public double Sum { get; set; }
        public string NameCategory { get; set; }

        //public CategoryInfo Next { get; set; }
        //public CategoryInfo Prev { get; set; }

        //public CategoryInfo(int day, int mounth, int year, int sum, string nameCat)
        //{
        //    Date = $"{day}.{mounth}.{year}";
        //    Day = day;
        //    Mounth = mounth;
        //    Year = year;
        //    Sum = sum;
        //    NameCategory = nameCat;
        //}                                                                           
        public List<Tranzactions> Needed = new();

        public CategoryInfo(int day, int mounth, int year, int sum, string nameCat)
        {
            Tranzactions first = new(day, mounth, year, sum);
            Needed.Add(first);
            NameCategory = nameCat;
        }
        public void AddTranz(int day, int mounth, int year, int sum)
        {
            Tranzactions newTranz = new(day, mounth, year, sum);
            Needed.Add(newTranz);
        }
        public void AddTranz(Tranzactions newTranz)
        {
            Needed.Add(newTranz);
        }
        public void AddTranz(Tranzactions newTranz, int index)
        {
            Needed.Insert(index, newTranz);
        }
        public void Delete(int day, int mounth, int year, int sum)
        {
            Tranzactions newTranz = new(day, mounth, year, sum);
            Needed.Remove(newTranz);
        }
        public void Delete(int index)
        {
            Needed.RemoveAt(index);
        }

    }
}
