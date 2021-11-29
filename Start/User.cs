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
        string UserName;

        public User(string userName)
        {
            UserName = userName;
        }

        public void AddNewCard(string cardName, double balance)
        {
            RealCard newCard = new(balance, cardName);
            Cards.Add(newCard);
        }
    }
    //добавить изменеине по дате начиная от года 
    // YYYYMMDD

}
