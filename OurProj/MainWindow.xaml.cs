using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Start;
using OurProj.PopupWindows;

namespace OurProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AllData AllInfo = AllData.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            ButtonInComboBoxForCards();
            ButtonInComboBoxForCategs();
            TabItemTranzactions.IsEnabled = false;
            ListViewAnalyticks.IsEnabled = false;
        }

        #region AddCard
        private void ButtonInComboBoxForCards()
        {
            Button add = new();
            add.Content = "New";
            add.Click += ButtonAddCard;
            ComboBoxCards.Items.Add(add);
        }

        private void ButtonAddCard(object sender, RoutedEventArgs e)
        {
            CreateCard toCreate = new(this);
            toCreate.Show();
            this.IsEnabled = false;
        }
        #endregion

        #region AddCateg
        private void ButtonInComboBoxForCategs()
        {
            Button add = new();
            add.Content = "New categ";
            add.Click += ButtonAddCateg;
            ComboBoxCategs.Items.Add(add);
        }
        private void ButtonAddCateg(object sender, RoutedEventArgs e)
        {
            WindowAddCategory toCreate = new(this);
            toCreate.Show();
            this.IsEnabled = false;
        }
        #endregion

        private void ButtonSelectUser_Click(object sender, RoutedEventArgs e)
        {

        }
        //del


        private void ComboBoxCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp;
            if (ComboBoxCards.SelectedItem is Label)
            {
                tmp = Convert.ToString(((Label)ComboBoxCards.SelectedItem).Content);
                RealCard card = AllInfo.user.GetActualCard(tmp);
                LabelCardName.Content = card.Name;
                LabelCardBalance.Content = card.Balance;
                TabItemTranzactions.IsEnabled = true;
                UtilLabelsVisibility();
                ChangeLabelInfo();
            }
        }


        public void ButtonTmp_Click(object sender, RoutedEventArgs e)
        {
            int i = -1;
            TextBoxTmp.Text = "";
            if (ComboBoxCategs.SelectedItem is Button)
            {
                string ttmp = Convert.ToString(((Button)ComboBoxCategs.SelectedItem).Content);
                RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
                StacPanelTranzactions.Children.Clear();
                while (++i < curCard.Tranzactions.Count)
                {
                    if (curCard.Tranzactions[i].CatName == ttmp)
                    {
                        Button tranz = new();
                        tranz.Content = curCard.Tranzactions[i].DateTranz + "\n" + curCard.Tranzactions[i].Sum + "\n";
                        if (curCard.Tranzactions[i].CashBack != 0)
                            tranz.Content += curCard.Tranzactions[i].CashBack +"";
                        tranz.Click += ForEveryTranzaction;
                        StacPanelTranzactions.Children.Add(tranz);
                        TextBoxTmp.Text += curCard.Tranzactions[i].DateTranz + "\n" + curCard.Tranzactions[i].Sum + "\n";
                    }
                }
            }
        }
        private void ForEveryTranzaction(object sender, RoutedEventArgs e)
        {
            string butinfo = Convert.ToString(((Button)sender).Content);
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            string categName = Convert.ToString(((Button)ComboBoxCategs.SelectedItem).Content);
            Tranz curTranz = Tranz.GetTranzaction(butinfo, categName);

            CorrectTranz win = new(this, curCard, curTranz);
            this.IsEnabled = false;
            win.Show();
            LabelCardName.Content = curCard.Name;
            LabelCardBalance.Content = curCard.Balance;
        }

        private void ButtonCrunhcForCashBack_Click(object sender, RoutedEventArgs e)
        {
            string catName;
            RealCard card = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            for (int i = 0; i < card.CashBacks.Count; i++)
            {
                Button newCateg = new();

                newCateg.Content = card.CashBacks[i].CatName;
                newCateg.Click += ButtonAddBought;
                if (IsExists(Convert.ToString(newCateg.Content)) == true)
                    ComboBoxCategs.Items.Add(newCateg);
                AllInfo.user.Categs.Add(card.CashBacks[i].CatName);
            }
        }
        private void ButtonAddBought(object sender, RoutedEventArgs e)
        {
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            string catName;

            catName = Convert.ToString(((Button)sender).Content);
            NewTranzaction addNew = new(this, catName, curCard);
            addNew.Show();

        }

        private void ButtonMonthAnalyticks_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime end = DateTime.Today;
            DateTime start = DateTime.Today.AddMonths(-1);
            AllInfo.user.MakeAnalyse(start, end);
            var kek = AllInfo.user.AnaliseData.ToList();
            DataContext = AllInfo.user;
            ListViewAnalyticks.ItemsSource = kek;
            ListViewAnalyticks.IsEnabled = true;
        }

        public void ChangeLabelInfo()
        {
            int spendedMoney = 0;
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(((Label)ComboBoxCards.SelectedItem).Content));
            LabelMainWBalance.Content = curCard.Balance;
            LabelCardBalance.Content = curCard.Balance;
            LabelMainWCasback.Content = curCard.AccumulatedCashback;
            foreach(Tranz temp in curCard.Tranzactions)
            {
                if (temp.CatName != "income")
                spendedMoney += temp.Sum;
            }
            LabelMainWTranzactions.Content = spendedMoney;
        }
        private void UtilLabelsVisibility()
        {
            LabelCashbackMainInfo.Visibility = Visibility.Visible;
            LabelMainWCasback.Visibility = Visibility.Visible;
            LabelBalanceMainInfo.Visibility = Visibility.Visible;
            LabelExpensesMainInfo.Visibility = Visibility.Visible;
            LabelMainWTranzactions.Visibility = Visibility.Visible;
            LabelMainWBalance.Visibility = Visibility.Visible;

            DatePickerForUnstagedTranz.Visibility = Visibility.Visible;
            RadioButtonUnstagedTranzactions.Visibility = Visibility.Visible;
            RadioButtonIncome.Visibility = Visibility.Visible;
            TextBoxSumOfTranz.Visibility = Visibility.Visible;
            ButtonAddUnstagedTranz.Visibility = Visibility.Visible;
        }
        public bool IsExists(string newCat)
        {
            for (int i = 0; i < AllInfo.user.Categs.Count; i++)
            {
                if (newCat == AllInfo.user.Categs[i])
                    return false;
            }
            return true;
        }

        private void ButtonAddUnstagedTranz_Click(object sender, RoutedEventArgs e)
        {
            string tmp;

            tmp = Convert.ToString(((Label)ComboBoxCards.SelectedItem).Content);
            RealCard curCard = AllInfo.user.GetActualCard(tmp);
            Tranz newTranz;
            DateTime datec;
            if (DatePickerForUnstagedTranz.SelectedDate != null)
                datec = (DateTime)DatePickerForUnstagedTranz.SelectedDate;
            else
                datec = DateTime.Today;
            if (RadioButtonIncome.IsChecked == true)
            {
                newTranz = new(datec, "income", Convert.ToInt32(TextBoxSumOfTranz.Text));
                AllInfo.user.tranzactions.Add(newTranz);
                curCard.Tranzactions.Add(newTranz);
                curCard.ChangeBalancePlus(newTranz.Sum);
            }
            else if (RadioButtonUnstagedTranzactions.IsChecked == true)
            {
                newTranz = new(datec, "unstaged", Convert.ToInt32(TextBoxSumOfTranz.Text));
                if (curCard.ChangeBalanceMinus(newTranz.Sum) == -1)
                    MessageBox.Show("Error. Not enough money");
                else
                {
                    AllInfo.user.tranzactions.Add(newTranz);
                    curCard.Tranzactions.Add(newTranz);
                }
            }
            ChangeLabelInfo();
        }

        private void TextBoxSumOfTranz_KeyDown(object sender, KeyEventArgs e)
        {
            int c = (Char)e.Key;
            if (((Char)e.Key >= 34 && (Char)e.Key <= 43))
            {
                e.Handled = false;
            }
            else if (((Char)e.Key >= 74 && (Char)e.Key <= 83))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
