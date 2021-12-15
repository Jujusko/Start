using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Start.Dinar.Categories;
using Start;

namespace Start
{
    public class User
    {
        public List<RealCard> Cards = new();
        public List<Deposit> Depos = new();
        public string UserName;
        public int Len;
        public List<string> Categs { get; set; }
        public List<Tranz> Tranzactions { get; set; }
        public List<Analytics> AnaliseData { get; set; }

        public User(string userName)
        {
            string income = "income";
            string unstaged = "unstaged";
            string deposit = "deposit";
            Categs = new(); Categs.Add(income); Categs.Add(unstaged); Categs.Add(deposit);
            Len = 0;
            UserName = userName;
            Tranzactions = new();
            AnaliseData = new();
        }

        public void AddNewCard(string cardName, int balance)
        {
            RealCard newCard = new(balance, cardName);
            Cards.Add(newCard);
            Len++;
        }
        public void NewTransaction(string cardName, int sum)
        {
            int i;

            i = -1;
            while(++i < Cards.Count)
            {
                if (Cards[i].Name == cardName)
                {
                    Cards[i].ChangeBalanceMinus(sum);
                    return;
                }
            }
            throw new Exception("Нет такой карты");
        }

        public RealCard GetActualCard(string cardName)
        {
            int i;

            i = 0;
            while (i < Cards.Count)
            {
                if (Cards[i].Name == cardName)
                    return Cards[i];
                i++;
            }
            throw new Exception("Этого никогда не произойдет");
        }
        public Deposit GetActualDeposit(string depoName)
        {
            for (int i = 0; i < Depos.Count; i++)
            {
                if (Depos[i].Name == depoName)
                    return Depos[i];
            }
            throw new Exception("Этого никогда не произойдет");
        }
        public void MakeAnalyse(DateTime start, DateTime end)
        {
            if (AnaliseData.Count != 0)
                AnaliseData.Clear();
            for (int i = 0; i < Categs.Count; i++)
            {
                Analytics tmp = AnaliseOneCategory(Categs[i], start, end);
                AnaliseData.Add(tmp);
            }
        }
        private Analytics AnaliseOneCategory(string category, DateTime start, DateTime end)
        {
            int avgSum;
            int amountSum = 0;
            int k, j;
            TimeSpan amountDays = end - start;
            for (int i = 0; i < Tranzactions.Count; i++)
            {
                if (Tranzactions[i].CatName == category &&
                    Tranzactions[i].DateTranz.CompareTo(start) >= 0 &&
                    Tranzactions[i].DateTranz.CompareTo(end) <= 0)
                {
                    amountSum += Tranzactions[i].Sum;
                }
            }
            avgSum = amountSum / amountDays.Days;
            return new Analytics(category, avgSum, amountSum, start, end);
        }
    }
    //добавить изменеине по дате начиная от года 
    // YYYYMMDD

}
