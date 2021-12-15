using Start;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для Deposit.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        private int[] Flag { get; set; }
        private AllData Data = AllData.GetInstance();
        private MainWindow _win { get; set; }
        public DepositWindow(MainWindow window)
        {
            _win = window;
            Flag = new int[5];
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            foreach (var temp in _win.ComboBoxCards.Items)
            {
                if (temp is Label)
                {
                    Label card = new();
                    card.Content = ((Label)temp).Content;
                    ComboBoxCards.Items.Add(card);
                }
            }
        }
        //dict bool

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData() == 1)
            {
                RealCard selectedCard = Data.user.GetActualCard(
                    Convert.ToString(((Label)ComboBoxCards.SelectedItem).Content));
                int balance = Convert.ToInt32(TextBoxStartBalance.Text);
                string name = TextBoxDepoName.Text;
                int percent = Convert.ToInt32(TextBoxPercent.Text);
                int amount = Convert.ToInt32(TextBoxAmountMonths.Text);
                Deposit newDepo = new(balance, name, amount, percent, selectedCard);
                if (selectedCard.ChangeBalanceMinus(balance) == 1)
                    Data.user.Depos.Add(newDepo);
                else
                {
                    MessageBox.Show("Not enought money!");
                    _win.IsEnabled = true;
                    this.Close();
                    return;
                }
                Tranz temp = new(DateTime.Now, "deposit", balance);
                Data.user.Tranzactions.Add(temp);
                Label depoInCBox = new();
                depoInCBox.Content = newDepo.Name;
                _win.ComboBoxDeposit.Items.Add(depoInCBox);
                this.Close();
                _win.ChangeLabelInfo();
                _win.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно");
            }
        }

        private int CheckData()
        {
            if (TextBoxDepoName.Text == ""
                || TextBoxAmountMonths.Text == ""
                || TextBoxPercent.Text == ""
                || TextBoxStartBalance.Text == "")
                return 0;
            for (int i = 0; i < Flag.Length; i++)
            {
                if (Flag[i] != 1)
                    return 0;
            }
            return 1;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox checker = (TextBox)sender;
            ((TextBox)sender).Text = "";
            if (checker.Name == TextBoxDepoName.Name)
                Flag[0] = 1;
            else if (checker.Name == TextBoxAmountMonths.Name)
                Flag[1] = 1;
            else if (checker.Name == TextBoxPercent.Name)
                Flag[2] = 1;
            else if (checker.Name == TextBoxStartBalance.Name)
                Flag[3] = 1;
        }

        private void TextBoxDigitsOnly(object sender, KeyEventArgs e)
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

        private void ComboBoxCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flag[4] = 1;
        }
    }
}
