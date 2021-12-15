using System;
using System.Collections.Generic;

namespace Start
{
    public class RealCard : AbstractCard
    {
        public override int Balance { get; set; }
        public override string Name { get; set; }
        public List<Tranz> Tranzactions { get; set; }

        public DateTime CashBackProfit { get; set; }
        public int AccumulatedCashback { get; set; }
        public List<CashBackByCategory> CashBacks { get; set; }
        AllData Castle = AllData.GetInstance();
        public RealCard(int balance, string name)
        {
            Balance = balance;
            Name = name;
            CashBacks = new();
            Tranzactions = new();
            AccumulatedCashback = 0;
        }


        public override int ChangeBalanceMinus(int money)
        {
            if (Balance < money)
                return -1;
            Balance -= money;
            return 1;
        }

        public int ChangeBalanceMinus(Tranz tranzaction)
        {
            if (Balance < tranzaction.Sum)
                return -1;
            Balance -= tranzaction.Sum;
            return 1;
        }

        public override int ChangeBalancePlus(int money)
        {
            Balance += money;
            return 1;
        }
        public void AddNewCashBack(string name, int percent)
        {
            CashBackByCategory newCashB = new(name, percent);
            CashBacks.Add(newCashB);
        }
        public void AccumulateCashBack(Tranz tranzaction)
        {
            for (int i = 0; i < CashBacks.Count; i++)
            {
                if (tranzaction.CatName == CashBacks[i].CatName)
                    AccumulatedCashback += tranzaction.Sum * CashBacks[i].Percent / 100;
            }
        }

        public void GetProfitFromCashBack()
        {
            DateTime today = DateTime.Now;
            if (today == CashBackProfit)
            {
                ChangeBalancePlus(AccumulatedCashback);
                Tranz newTranz = new(today, "cashback", AccumulatedCashback);
                AccumulatedCashback = 0;
                Tranzactions.Add(newTranz);
                Castle.user.Tranzactions.Add(newTranz);
                CashBackProfit.AddMonths(1);
            }
        }
        //TODO дописать окно, проверить все поля. КБПрофит будем получать из окна fillCBField, концептуально
        //в одном окне можно добавить несколько категорий (лдве кнопки и нажатие на одну из них заново открывает другую)
    }

}
