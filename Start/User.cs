using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class User
    {
        List<RealCard> Cards = new();
        public string UserName;

        public User(string userName)
        {
            UserName = userName;
        }

        public void AddNewCard(string cardName, int balance)
        {
            RealCard newCard = new(balance, cardName);
            Cards.Add(newCard);
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
