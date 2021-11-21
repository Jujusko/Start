using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Dinar.Categories
{
    public class Category
    {
        [Flags]
        public enum Flags
        {
            Food,
            Taxi,
            Home
        }
        public CategoryInfo[] CurrentCategory { get; set; }
        public int Len { get; set; }

        public Category(CategoryInfo Category, Flags cats)
        {

            int numbCategory;

            numbCategory = ChooseCategory(cats);
            CurrentCategory = new CategoryInfo[10];
            CurrentCategory[numbCategory] = Category;
            CurrentCategory[numbCategory].Next = null;
            CurrentCategory[numbCategory].Prev = null;
        }

        public void AddNewPurchase(CategoryInfo curCat, int numbCategory)
        {
            CategoryInfo tmp;

            tmp = CurrentCategory[numbCategory];
            while (tmp.Next != null)
                tmp = tmp.Next;
            tmp.Next = curCat;
            tmp.Next.Prev = tmp;
        }
        public void AddNewPurchaseByDate(string date, int sum, Flags cats)
        {
            int day;
            int mounth;
            int year;
            int flag;
            int numbCategory;
            CategoryInfo newNode;
            CategoryInfo treatHead;

            numbCategory = ChooseCategory(cats);
            day = (Convert.ToInt32(date[0]) - 48) * 10 + (Convert.ToInt32(date[1]) -48);
            mounth = (Convert.ToInt32(date[3]) - 48) * 10 + (Convert.ToInt32(date[4]) - 48);
            year = (Convert.ToInt32(date[6]) - 48) * 1000 + (Convert.ToInt32(date[7]) - 48) * 100 +
                (Convert.ToInt32(date[8]) - 48) * 10 + (Convert.ToInt32(date[9]) - 48);
            newNode = new(day, mounth, year, sum, numbCategory);

            CategoryInfo tmp = CurrentCategory[numbCategory];
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
                    newNode.Next = CurrentCategory[numbCategory];
                    newNode.Next.Prev = newNode;
                    CurrentCategory[numbCategory] = newNode;
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
        public void PutToConsole(Flags op)
        {
            CategoryInfo tmp;

            tmp = CurrentCategory[ChooseCategory(op)];
            while (tmp != null)
            {
                Console.WriteLine(tmp.Date);
                Console.WriteLine(tmp.Sum);
                Console.WriteLine(tmp.NameCategory);
                tmp = tmp.Next;
            }
        }

        private int ChooseCategory(Flags flag)
        {
            if (flag == Flags.Food)
            {
                return 0;
            }
            else if (flag == Flags.Taxi)
            {
                return 1;
            }
            else
            {
                throw new Exception("Нет категории");
            }
        }
        public void NewCategory(CategoryInfo newCategory, Flags cats)
        {
            CurrentCategory[ChooseCategory(cats)] = newCategory;
        }
    }
}
