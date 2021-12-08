using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contributions
{
    public abstract class Transaction
    {
        public abstract string Date { get; set; } // календарик для впф
        public abstract string Name { get; set; }
        public abstract double SummPlus { get; set; }
        public abstract double SummMinus { get; set; }

        public string WriteDate()
        {
            return Date;
        }
        public string WriteName()
        {
            return Name;
        }
        public double WriteSummPlus()
        {
            return SummPlus;
        }
        public double WriteSummMinus()
        {
            return SummMinus;
        }

        public Transaction(string date, string name, double summplus, double summminus)
        {
            Date = date;
            Name = name;
            SummPlus = summplus;
            SummMinus = summminus;
        }
        public Transaction(string date, string name, double summplus)
        {
            Date = date;
            Name = name;
            SummPlus = summplus;
        }

    }
}
