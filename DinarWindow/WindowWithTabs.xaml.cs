﻿using System;
using DinarWindow.Cards;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Start;
using Start.Dinar.Categories;

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для WindowWithTabs.xaml
    /// </summary>
    public partial class WindowWithTabs : Window
    {
        public AllData Garbage = AllData.GetInstance();
        public RealCard current_card;
        public WindowWithTabs()
        {
            InitializeComponent();
            CrunchForAddCard();
            CrunchForAddCategs();
        }

        private void CrunchForAddCard()
        {
            Button tmpButton;

            tmpButton = new();
            tmpButton.Content = "Добавить карту";
            tmpButton.Click += ButtonAddCard_Click;
            ComboBoxCards.Items.Add(tmpButton);
        }
        private void CrunchForAddCategs()
        {
            Button tmpButton;

            tmpButton = new();
            tmpButton.Content = "Добавить";
            tmpButton.Click += ButtonAddCategory_Click;
            ComboBoxCategs.Items.Add(tmpButton);
        }
        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Categs addCategory = new Categs(this);
            addCategory.Show();
            this.IsEnabled = false;
        }
        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            RealCard tmpCard;

            tmpCard = Garbage.user.GetActualCard(Convert.ToString(Label2.Content));
            AddByCategoryName tmp = new(this, Convert.ToString(((Button)sender).Content), tmpCard.Balance);
            this.IsEnabled = false;
            tmp.Show();
        }


        public void CreateCategory(int sum, string name, int balance, string date)
        {
            Button tmpButton;
            int res;
            current_card = Garbage.user.GetActualCard(Convert.ToString(Label2.Content));

            tmpButton = new();
            res = Garbage.user.bla.NewOrAdd(name, date, sum, balance);
            if (res == 0)
            {
                current_card.Balance -= sum;
                tmpButton.Content = name;
                tmpButton.Click += ButtonAddData_Click;
                ComboBoxCategs.Items.Add(tmpButton);
            }
            else if (res == -1)
                return;
            TextBoxTest.Text = name;
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            CreateCardWindow add = new CreateCardWindow(this);
            add.Show();
            this.IsEnabled = false;
        }

        public void CreateCard(string cardName, int balance)
        {
            Label tmp = new();

            tmp.Content = cardName;
            Garbage.user.AddNewCard(cardName, balance);
            ComboBoxCards.Items.Add(tmp);
        }

        private void ComboBoxCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RealCard tmp;

            Label2.Content = ((Label)ComboBoxCards.SelectedItem).Content;
            tmp = Garbage.user.GetActualCard(Convert.ToString(Label2.Content));
            LabelCurCardBalance.Content = tmp.Balance;
        }

        private void ButtonAllBoughts_Click(object sender, RoutedEventArgs e)
        {
            string str;
            int i;
            CategoryInfo neededCat;

            str = TextBoxChooseCategoryToSeeAll.Text;
            neededCat = Garbage.user.bla.GetCategory(str);
            i = 0;
            if (StacPanelAllBoughts.Children.Count > 0)
            {
                StacPanelAllBoughts.Children.RemoveAt(StacPanelAllBoughts.Children.Count - 1);
            }
            while (i < neededCat.Needed.Count)
            {
                Button createdBut = new();
                StacPanelAllBoughts.Children.Add(createdBut);
                createdBut.Content = neededCat.Needed[i].Date + "\n" + neededCat.Needed[i].Sum;
                createdBut.Click += ButtonBoughtInfo;
                i++;
            }
        }
        private void ButtonBoughtInfo(object sender, RoutedEventArgs e)
        {
            string[] splt;
            splt = Convert.ToString(((Button)sender).Content).Split("\n");
            CorrectConcreteBought tmp = new CorrectConcreteBought(Convert.ToInt32(splt[1]), splt[0], this);
            tmp.Show();
            this.IsEnabled = false;

        }
        public void ChangeTranzaction(string catName, int sum, string date, int flag, int prevSum, string prevDate)
        {
            if (flag == 1)
                Garbage.user.bla.ChangeTranzaction(catName, sum, date, prevSum, prevDate);
            else
                Garbage.user.bla.DeleteTranzaction(catName, prevSum, prevDate);
            this.IsEnabled = true;
        }
    }
}