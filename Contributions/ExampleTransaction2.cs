using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    class ExampleTransaction2 : AbstractTransaction
    {
        public override string Date { get; set; } // календарик для впф
        public override string Name { get; set; }
        public override double SummPlus { get; set; }
        public override double SummMinus { get; set; }

        public ExampleTransaction2(string date, string name, double summplus, double summminus)
        {
            Date = date;
            Name = name;
            SummPlus = summplus;
        }
    }
}
