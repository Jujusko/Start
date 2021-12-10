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
        public List<Tranz> Tranzactions { get; set; }

        public RealCard(int balance, string name)
        {
            Balance = balance;
            Name = name;
            Tranzactions = new();
        }


        public override int ChangeBalanceMinus(int money)
        {
            if (Balance < money)
                return -1;
            Balance -=money;
            return 1;
        }

        public override int ChangeBalancePlus(int money)
        {
            Balance += money;
            return 1;
        }
    }

}
