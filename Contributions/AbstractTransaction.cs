using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    public abstract class AbstractTransaction
    {
        public abstract string Date { get; set; } // календарик для впф
        public abstract string Name { get; set; }
        public abstract double SummPlus { get; set; }
        public abstract double SummMinus { get; set; }

        public void WriteDate()
        {
            Console.WriteLine(Date);
        }
        public void WriteName()
        {
            Console.WriteLine(Name);
        }
        public void WriteSummPlus()
        {
            Console.WriteLine(SummPlus);
        }
        public void WriteSummMinus()
        {
            Console.WriteLine(SummMinus);
        }
        //return string
    }
}
