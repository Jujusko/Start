using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    public class ContributionPlus : Contribution
    {
        //public override string Name { get; set; }
        //public override int Balance { get; set; }
        //public override string Date { get; set; } // календарик для впф
        //public override int TermOfDeposit { get; set; } // срок вклада в месяцах//int
        //public override double Procent { get; set; }
        public int SummaPopolneniya { get; set; }

        public ContributionPlus(string name, int summ, string date, int termofdeposit, double procent, int summapopolneniya) :
            base(name, summ, date, termofdeposit, procent)
        {
            SummaPopolneniya = summapopolneniya;
        }

        //начисление процентов
        public override int PlusProcent()
        {
            int plusprocent = 0;

            string newdata = DataToEnd();     // 09.08.22 дата закрытия вклада
            string todaydata = DataToNow();       // 09.07.21 дата сегодняшняя, на данный момент 

            string todayday = DayToNow(); // 09 день на данный момент
            string dayopen = DayOpenContribution(); // 09 день открытия вклада


            if (newdata != todaydata) 
            {
                //while (DataMonthToNow() == DataMonthToDate()) // месяц сегодняшней даты == месяц открытия вклада
                //{

                    int nextmonth = Convert.ToInt32(DataMonthToDate());
                // месяц открытия вклада 06 = 6
                /*int nextmonth = Convert.ToInt32(ChangeMonth()) - 1;*/ // след месяц после открытия вклада 07 - 1 = 6

                if (nextmonth == 1 || nextmonth == 3 || nextmonth == 5 || nextmonth == 7 || nextmonth == 8 ||
                        nextmonth == 10 || nextmonth == 12)
                    {
                        if (String.Compare(todayday, dayopen) == 1)
                        {
                            plusprocent = Convert.ToInt32((Summ * Procent * 31 / 365) / 100);
                            Summ += plusprocent + SummaPopolneniya;
                            nextmonth = ChangeMonth(nextmonth); // 7
                        }
                    }

                    if (nextmonth == 2)
                    {
                        if (String.Compare(todayday, dayopen) == 1)
                        {
                            plusprocent = Convert.ToInt32((Summ * Procent * 28 / 365) / 100);
                            Summ += plusprocent + SummaPopolneniya;
                            nextmonth = ChangeMonth(nextmonth);
                        }
                    }

                    if (nextmonth == 4 || nextmonth == 6 || nextmonth == 9 || nextmonth == 11)
                    {
                        if (String.Compare(todayday, dayopen) == 1)
                        {
                            plusprocent = Convert.ToInt32((Summ * Procent * 30 / 365) / 100);
                            Summ += plusprocent + SummaPopolneniya;
                            nextmonth = ChangeMonth(nextmonth);
                        }
                    }
                //}

                return 1;
            }
            else
            {
                return (-1);
            }
        }

    }
}
