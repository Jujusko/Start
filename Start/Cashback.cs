using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    class Cashback : AbstractCard
    {
        public override int Balance { get; set; }//accumulated cashback
        public override string Name { get; set; }//catname
        public double Percent { get; set; }

        RealCard CardWithCashBack { get; set; }
        public DateTime DateOfPlus { get; set; }
        public List<CashBackByCategory> CasbBacks { get; set; }
        AllData Data = AllData.GetInstance();

        public Cashback (int percent, RealCard Card)
        {
            Balance = 0;
            CardWithCashBack = Card;
            Percent = percent;
        }
        public override int ChangeBalanceMinus(int money)
        {
            throw new NotImplementedException();
        }

        public override int ChangeBalancePlus(int money)
        {
            DateTime today = DateTime.Now;
            if (today.Day == DateOfPlus.Day)
            {

            }
            return 1;
        }
    }
}
