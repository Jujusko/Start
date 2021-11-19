using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public abstract class AbstractCard
    {
        public abstract double Balance { get; set; }
        public abstract double CashBack { get; set; }//сколько %
        public abstract double Deposite { get; set; }
        public abstract double AccumulatedCashBack { get; set; }// сколько рублей за месяц накоплено
        public abstract string Name { get; set;}

        public AbstractCard()
        {

        }

        public abstract void WriteBalance();
        public abstract void ChangeBalance(int money);// Руслан на реализацию
        public abstract void CheckCashBack();//Ася. Если получится, круто, нет - плевать
    }
}
