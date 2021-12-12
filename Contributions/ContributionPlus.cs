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

            string newdata = DataToEnd(); // 09.08.22
            string today = DataToNow(); //09.07.21
            string nextmonth = DataToStart(); // 08.06.21

            if (newdata != today)
            {
                while (DataMonthToNow() == DataMonthToDate())
                {
                    int month = Convert.ToInt32(DataMonthToDate());

                    if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 ||
                        month == 10 || month == 12) && String.Compare(nextmonth, today))
                    {
                        plusprocent = Convert.ToInt32((Summ * Procent * 31 / 365) / 100);
                        Summ += plusprocent + SummaPopolneniya;

                    }
                    if ((month == 2) && String.Compare(nextmonth, today))
                    {
                        plusprocent = Convert.ToInt32((Summ * Procent * 28 / 365) / 100);
                        Summ += plusprocent + SummaPopolneniya;
                    }
                    if ((month == 4 || month == 6 || month == 9 || month == 11) && String.Compare(nextmonth, today))
                    {
                        plusprocent = Convert.ToInt32((Summ * Procent * 30 / 365) / 100);
                        Summ += plusprocent + SummaPopolneniya;
                    }
                }
                string nextmonth = ChangeMonth();
                return 1;
            }
            else
            {
                return (-1);
            }
        }

    }
}
