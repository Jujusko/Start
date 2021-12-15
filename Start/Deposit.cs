using System;

namespace Start
{
    public class Deposit : AbstractCard
    {
        public override int Balance { get; set; }
        public override string Name { get; set; }
        public DateTime Profit { get; set; }
        public DateTime CloseDate { get; set; }
        public int Percent { get; set; }
        public bool Active { get; set; }

        public RealCard PaymentAndProfitPlace { get; set; }


        public Deposit(int balance, string name, int amountMonths, int percent, RealCard linkToCard)
        {
            Profit = DateTime.Today.AddMonths(1);
            CloseDate = DateTime.Today.AddMonths(amountMonths);
            Percent = percent;
            Balance = balance;
            Active = true;
            Name = name;
            PaymentAndProfitPlace = linkToCard;
        }
        public override int ChangeBalanceMinus(int money)
        {
            throw new NotImplementedException();
        }

        public override int ChangeBalancePlus(int money)
        {
            throw new NotImplementedException();
        }
        public int GetProfit(DateTime day)
        {
            if (Active == true)
            {
                if (day.Date == Profit.Date)
                {
                    PaymentAndProfitPlace.ChangeBalancePlus(Balance * Percent / 100);
                }
                if (CloseDeposit(0, day) == 1)
                    return 1;
            }
            return 0;
        }
        public int CloseDeposit(int flag, DateTime day)
        {
            if ((flag == 1 || day.Date == CloseDate)
                && Active == true)
            {
                PaymentAndProfitPlace.ChangeBalanceMinus(Balance);
                Active = false;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
