using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class User
    {
        public List<RealCard> Cards = new();
        public string UserName;
        public int Len;

        public User(string userName)
        {
            Len = 0;
            UserName = userName;
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
                    Cards[i].ChangeBalance(sum);
                    return;
                }
            }
            throw new Exception("Нет такой карты");
        }
    }
    //добавить изменеине по дате начиная от года 
    // YYYYMMDD

}
