namespace Start.Dinar.Categories
{
    public class Tranzactions
    {
        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }

        public string Date { get; set; }
        public double Sum { get; set; }

        public Tranzactions(int day, int mounth, int year, int sum)
        {
            Date = $"{day}.{mounth}.{year}";
            Day = day;
            Mounth = mounth;
            Year = year;
            Sum = sum;
        }
        public Tranzactions(string date, int sum)
        {
            Date = date;
            Sum = sum;
        }
        public override string ToString()
        {
            string s;

            s = "";
            s = Date + Sum;
            return s;
        }
    }
}
