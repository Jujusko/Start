﻿using System;

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


        public Categories()
        {
            CurrentCategory = new CategoryInfo[20];
            Len = 0;
        }

        public int AddNewPurchaseByDate(string date, int sum, string category, int balance)
        {
            int day;
            int mounth;
            int year;
            int numbCategory;
            CategoryInfo neededCat;
            Tranzactions newTranz;
            int i;

            numbCategory = ChooseCategory(category);
            if (balance < sum || numbCategory == -1)
                return -1;
            (day, mounth, year) = DateInfo(date);
            newTranz = new(day, mounth, year, sum);
            neededCat = CurrentCategory[numbCategory];
            i = -1;
            while (++i < neededCat.Needed.Count)
            {

                if (CheckTranzPlace(newTranz, neededCat.Needed[i]) == 0)
                    break;
            }
            neededCat.AddTranz(newTranz, i);
            return 1;
        }
        private int CheckTranzPlace(Tranzactions toAdd, Tranzactions current)
        {
            int toAddSum;
            int curSum;

            toAddSum = toAdd.Year * 100 + toAdd.Mounth * 100 + toAdd.Day;
            curSum = current.Year * 100 + current.Mounth * 100 + current.Day;
            if (toAddSum > curSum)
                return 1;
            return 0;
        }
        public string PutToConsole(string category)
        {
            CategoryInfo tmp;
            string str = "";
            int index;


            index = ChooseCategory(category);
            if (index == -1)
            {
                return ("нет такой каты");
            }
            tmp = CurrentCategory[ChooseCategory(category)];
            index = -1;
            while (++index < tmp.Needed.Count)
            {
                str += tmp.Needed[index].Date + " " + tmp.Needed[index].Sum + "\n";
            }
            return str;
        }

        public string GetInfoAboutBought(string category)
        {
            CategoryInfo tmp;
            string info;

            tmp = CurrentCategory[ChooseCategory(category)];
            info = tmp.Needed[tmp.Needed.Count].Date + "\n" + tmp.NameCategory + "\n" + tmp.Needed[tmp.Needed.Count];
            return info;
        }

        private int ChooseCategory(string category)
        {
            int i = 0;
            while (i < Len)
            {
                if (CurrentCategory[i].NameCategory == category)
                    return i;
                i++;
            }
            return (-1);
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

            if (date != null && date != "")
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

        public int NewOrAdd(string categoryName, string date, int sum, int balance)
        {
            int i;

            i = 0;
            if (sum > balance)
            {
                return -1;
            }
            while (i < CurrentCategory.Length)
            {
                if (CurrentCategory[i] != null && CurrentCategory[i].NameCategory == categoryName)
                {
                    if (AddNewPurchaseByDate(date, sum, categoryName, balance) == -1)
                        return -1;
                    i = -1;
                    //return 1;
                }
                i++;
            }
            if (i != -1)
            {
                NewCategory(categoryName, sum, date);
                return 1;
            }
            return 0;
        }
        private (int, int, int) DateInfo(string date)
        {
            DateTime today = DateTime.Now;
            int[] splitString = new int[3];
            int i;
            string[] separs;

            if (date == null || date == "")
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
            while (i <= Len)
            {
                s = s + CurrentCategory[i].NameCategory;
                i++;
            }
            return s;
        }

        public CategoryInfo GetCategory(string catName)
        {
            CategoryInfo[] tmp;
            int i;

            i = 0;
            tmp = CurrentCategory;
            while (i < tmp.Length && tmp[i] != null)
            {
                if (tmp[i].NameCategory == catName)
                    return tmp[i];
                i++;
            }
            throw new Exception("Этого не должно произойти");
        }


    }
}
