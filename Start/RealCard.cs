using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class RealCard:AbstractCard
    {
        public override int Balance { get; set ; }
        public override double CashBack { get ; set ; }
        public override double Deposite { get ; set; }
        public override string Name { get; set; }
        public override double AccumulatedCashBack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RealCard(int balance, string name)
        {
            Balance = balance;
            Name = name;

            Console.WriteLine($"You success created card {name}. Current balance is {balance}.");
        }

        public override void WriteBalance()
        {
            Console.WriteLine(Balance);
        }

        public override void ChangeBalance(int money)
        {
            Balance -=money;
            //throw new NotImplementedException();//Руслан на реализацию
        }

        public override void CheckCashBack()
        {
            throw new NotImplementedException();//Ася. Если получится, круто, нет - плевать
        }
    }

}
