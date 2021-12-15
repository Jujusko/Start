using System;

namespace Start
{
    public class Analytics
    {
        public string CatName { get; set; }
        public int AvgSum { get; set; }
        public int AmountSum { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }

        public Analytics(string catName, int avgSum, int amountSum, DateTime start, DateTime end)
        {
            CatName = catName;
            AvgSum = avgSum;
            AmountSum = amountSum;
            Start = start;
            End = end;
        }
    }
}
