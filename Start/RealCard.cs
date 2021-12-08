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
        public override string Name { get; set; }
        public int Index { get; set; }
        public int Tranzactions { get; set; }

        public RealCard(int balance, string name, int index)
        {
            Balance = balance;
            Name = name;
            Index = index;
            Console.WriteLine($"You success created card {name}. Current balance is {balance}.");
        }


        public override void ChangeBalanceMinus(int money)
        {
            Balance -=money;
            Tranzactions += money;
            //throw new NotImplementedException();//Руслан на реализацию
        }

        public override void ChangeBalancePlus(int money)
        {
            Balance -= money;
            Tranzactions += money;
            //throw new NotImplementedException();//Руслан на реализацию
        }
    }

}
