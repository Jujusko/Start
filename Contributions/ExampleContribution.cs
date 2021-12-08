using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    class ExampleContribution : AbstractionContribution
    {
        public override string Name { get; set; }
        public override double Summ { get; set; }
        public override string Date { get; set; } // календарик для впф
        public override double TermOfDeposit { get; set; } // срок вклада в месяцах//int
        public override double Procent { get; set; }

        public ExampleContribution(string name, double summ, string date, double termofdeposit, double procent)
        {
            Name = name;
            Summ = summ;
            Date = date;
            TermOfDeposit = termofdeposit; 
            Procent = procent;
        }
    }
}
