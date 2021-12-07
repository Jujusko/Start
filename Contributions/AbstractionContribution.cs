using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    public abstract class AbstractionContribution
    {
        public abstract string Name { get; set; }
        public abstract double Summ { get; set; }
        public abstract string Date { get; set; } // календарик для впф
        public abstract double TermOfDeposit { get; set; } // срок вклада в месяцах
        public abstract double Procent { get; set; }

        public void WriteName()
        {
            Console.WriteLine(Name);
        }
        public void WriteSumm()
        {
            Console.WriteLine(Summ);
        }
        public void WriteDate()
        {
            Console.WriteLine(Date);
        }
        public void WriteTermOfDeposit()
        {
            Console.WriteLine(TermOfDeposit);
        }
        public void WriteProcent()
        {
            Console.WriteLine(Procent);
        }

    }
}
