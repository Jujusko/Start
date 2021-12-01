using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Dinar.Categories
{
    public class Categories
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

        public Categories(CategoryInfo Category, Flags cats)
        {

            int numbCategory;
            Len = 0;

            numbCategory = Len;
            CurrentCategory = new CategoryInfo[10];
            CurrentCategory[numbCategory] = Category;
            CurrentCategory[numbCategory].Next = null;
            CurrentCategory[numbCategory].Prev = null;
        }
        public Categories()
        {
            CurrentCategory = new CategoryInfo[20];
            Len = 0;
        }

        public void AddNewPurchaseByDate(string date, int sum, string category)
        {
            int day;
            int mounth;
            int year;
            int flag;
            int numbCategory;
            CategoryInfo newNode;
            CategoryInfo treatHead;
            DateTime today = DateTime.Now;

            numbCategory = ChooseCategory(category);
            (day, mounth, year) = DateInfo(date);
            newNode = new(day, mounth, year, sum, category);

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
        public string PutToConsole(string category)
        {
            CategoryInfo tmp;
            string str = "";

            tmp = CurrentCategory[ChooseCategory(category)];
            while (tmp != null)
            {
                str += tmp.Date + " " + tmp.Sum + "\n";
                tmp = tmp.Next;
            }
            return str;
        }

        public string GetInfoAboutBought(string category)
        {
            CategoryInfo tmp;
            string info;

            tmp = CurrentCategory[ChooseCategory(category)];
            info = tmp.Date + "\n" + tmp.NameCategory + "\n" + tmp.Sum;
            return info;
        }

        private int ChooseCategory(string category)
        {
            int i = 0;
            while(i < Len)
            {
                if (CurrentCategory[i].NameCategory == category)
                    return i;
                i++;
            }
            throw new Exception("Нет такой категории");
        }
        public void NewCategory(CategoryInfo newCategory)
        {
            Len++;
            CurrentCategory[Len] = newCategory;
        }
        public void NewCategory(string categoryName, int sum, string date)
        {
            int day, mounth, year;
            DateTime today = DateTime.Now;

            if (date != null)
                (day, mounth, year) = DateInfo(date);
            else
            {
                day = today.Day;
                mounth = today.Month;
                year = today.Year;
            }
            if (Len == 0)
            {
                CurrentCategory[Len] = new(day, mounth, year, sum, categoryName);
                Len++;
            }
            else
            {
                CurrentCategory[Len] = new(day, mounth, year, sum, categoryName);
                Len++;
            }
        }

        public int NewOrAdd(string categoryName, string date, int sum)
        {
            int i;

            i = 0;
            while(i < CurrentCategory.Length)
            {
                if (CurrentCategory[i] != null && CurrentCategory[i].NameCategory == categoryName)
                {
                    AddNewPurchaseByDate(date, sum, categoryName);
                    i = -1;
                    return 1;
                }
                i++;
            }
            if (i != -1)
            {
                NewCategory(categoryName, sum, date);
            }
            return 0;
        }
        private (int, int, int) DateInfo(string date)
        {
            DateTime today = DateTime.Now;
            int[] splitString = new int[3];
            int i;
            string[] separs;

            if (date == null)
            {
                return (today.Day, today.Month, today.Year);
            }
            separs = date.Split('/');
            i = -1;
            while (++i < separs.Length)
            {
                splitString[i] = Convert.ToInt32(separs[i]);
            }
            return (splitString[1], splitString[0], splitString[2]);

        }
        public string PrintCats()
        {
            int i = 0;
            string s = "";
            while(i <= Len)
            {
               s = s + CurrentCategory[i].NameCategory;
                i++;
            }
            return s;
        }
    }
}
