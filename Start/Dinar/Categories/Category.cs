using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Dinar.Categories
{
    public class Category
    {
       public CategoryInfo CurrentCategory { get; set; }

        public Category(CategoryInfo Category)
        {
            CurrentCategory = Category;
            CurrentCategory.Next = null;
            CurrentCategory.Prev = null;
        }

        public void AddNewPurchase(CategoryInfo curCat)
        {
            CategoryInfo tmp;

            tmp = CurrentCategory;
            while (tmp.Next != null)
                tmp = tmp.Next;
            tmp.Next = curCat;
            tmp.Next.Prev = tmp;
        }
        public void AddNewPurchaseByDate(string date, int sum, string nameCat)
        {
            int day;
            int mounth;
            int year;
            int flag;
            CategoryInfo newNode;
            CategoryInfo treatHead;

            day = (Convert.ToInt32(date[0]) - 48) * 10 + (Convert.ToInt32(date[1]) -48);
            mounth = (Convert.ToInt32(date[3]) - 48) * 10 + (Convert.ToInt32(date[4]) - 48);
            year = (Convert.ToInt32(date[6]) - 48) * 1000 + (Convert.ToInt32(date[7]) - 48) * 100 +
                (Convert.ToInt32(date[8]) - 48) * 10 + (Convert.ToInt32(date[9]) - 48);
            newNode = new(day, mounth, year, sum, nameCat);

            CategoryInfo tmp = CurrentCategory;
            flag = 1;
            treatHead = tmp;
            while(tmp.Next != null)
            {
                if (FrontOrBack(tmp.Next, newNode) == 0 && FrontOrBack(tmp, newNode) == 1)
                {
                    newNode.Next = tmp.Next;
                    tmp.Next = newNode;
                    tmp.Next.Prev = tmp;
                    flag = 0;
                }
                tmp = tmp.Next;
            }
            if (flag == 1)
            {
                if (FrontOrBack(tmp, newNode) == 0)
                {
                    newNode.Next = CurrentCategory;
                    newNode.Next.Prev = newNode;
                    CurrentCategory = newNode;
                }
                else
                {
                    tmp.Next = newNode;
                    tmp.Next.Prev = tmp;
                }
            }
        }

        private int FrontOrBack(CategoryInfo nodeToCmp, CategoryInfo toAddNode)
        {
            if (nodeToCmp.Year == toAddNode.Year)
            {
                if (nodeToCmp.Mounth == toAddNode.Mounth)
                {
                    if (nodeToCmp.Day == toAddNode.Day)
                        return 1;
                    else if (nodeToCmp.Day < toAddNode.Day)
                        return 1;
                    else
                        return 0;
                }
                else if (nodeToCmp.Mounth < toAddNode.Mounth)
                    return 1;
                else
                    return 0;
            }
            else if (nodeToCmp.Year < toAddNode.Year)
                return 1;
            else
                return 0;
        }
        public void PutToConsole()
        {
            CategoryInfo tmp;

            tmp = CurrentCategory;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Date);
                Console.WriteLine(tmp.Sum);
                Console.WriteLine(tmp.NameCategory);
                tmp = tmp.Next;
            }
        }
    }
}
