using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contributions
{
    public class Contribution
    {
        public string Name { get; set; }
        public double Summ { get; set; }
        public string Date { get; set; } // календарик для впф // 05/05/2021
        public int TermOfDeposit { get; set; } // срок вклада в месяцах // 12
        public double Procent { get; set; }
        public double  SummaPopolneniya { get; set; }
        public double SummaSnyatiyaiya { get; set; }
        public Contribution(string name, double summ, string date, int termofdeposit, double procent)
        {
            Name = name;
            Summ = summ;
            Date = date;
            TermOfDeposit = termofdeposit;
            Procent = procent;
        }

        #region
        //public string WriteName()
        //{
        //    return Name;
        //}
        //public double WriteSumm()
        //{
        //    return Summ;
        //}
        //public string WriteDate()
        //{
        //    return Date;
        //}
        //public int WriteTermOfDeposit()
        //{
        //    return TermOfDeposit;
        //}
        //public double WriteProcent()
        //{
        //    return Procent;
        //}
        #endregion 

        //дата закрытия вклада 
        public string DateToEnd(string Date, int TermOfDeposit)
        {
            string newday = Date.Substring(0, 5); // "чт 05.05.2020"      чт 05
            int newmonth = Convert.ToInt32(Date.Substring(6, 2)) + TermOfDeposit; // 05 + 12 = 17       05 + 13 = 18
            int plusyear = newmonth / 12; // 18 / 12 = 1
            int newyear = Convert.ToInt32(Date.Substring(9, 4)) + plusyear; // 2020 + 1 = 2021
            newmonth = newmonth % 12; // 18 % 12 = 6
            string newmonth2 = "0";
            if (newmonth < 10)
            {
                newmonth2 = "0" + Convert.ToString(newmonth);
            }
            string newdata = (newday) + "." + newmonth2 + "." + Convert.ToString(newyear);

            return newdata;
        }

        public void PlusProcent()
        {
            double summcontributiontoendsrok = 0;
            double plussumm = 0;
            DateToEnd();
            while (!newdata)
            {
                if ()
                    plusprocent = (Summ * Procent * 31 / 365) / 100;
                if ()
                    plusprocent = (Summ * Procent * 28 / 365) / 100;
                if ()
                    plusprocent = (Summ * Procent * 30 / 365) / 100;
            }
        }
    }
}
