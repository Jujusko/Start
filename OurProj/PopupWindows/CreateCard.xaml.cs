using Start;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        private AllData AllInfo = AllData.GetInstance();
        private MainWindow _window { get; set; }
        private RealCard Card { get; set; }
        public CreateCard(MainWindow win)
        {
            InitializeComponent();
            _window = win;
            ButtonAddCashBack.IsEnabled = false;
            ButtonOK.IsEnabled = false;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            //int balance;
            _window.IsEnabled = true;
            this.Close();
        }

        private void ButtonAddCashBack_Click(object sender, RoutedEventArgs e)
        {
            FillCashBackField window = new(_window, Card);

            window.Show();
            ButtonOK.IsEnabled = true;
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            int balance;
            string name;
            RealCard newCard;
            Label card = new();

            if (TextBoxBalance.Text == "" ||
                TextBoxBalance.Text == null)
                balance = 0;
            else
                balance = Convert.ToInt32(TextBoxBalance.Text);
            name = TextBoxName.Text;
            card.Content = name;
            newCard = new(balance, name);
            Card = newCard;
            AllInfo.user.Cards.Add(newCard);

            _window.ComboBoxCards.Items.Add(card);
            ButtonOK.IsEnabled = true;
            ButtonAddCashBack.IsEnabled = true;

        }

        private void TextBoxBalance_PreviewKeyDown(object sender, KeyEventArgs e)
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
            else if ((Char)e.Key == 2)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
