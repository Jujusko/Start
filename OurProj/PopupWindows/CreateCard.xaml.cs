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
using System.Windows.Shapes;
using Start;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        private AllData AllInfo = AllData.GetInstance();
        private MainWindow _window { get; set; }
        public CreateCard(MainWindow win)
        {
            InitializeComponent();
            _window = win;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            int balance;
            string name;
            RealCard newCard;
            Label card = new();

            balance = Convert.ToInt32(TextBoxBalance.Text);
            name = TextBoxName.Text;
            card.Content = name;
            newCard = new(balance, name);
            AllInfo.user.Cards.Add(newCard);

            _window.ComboBoxCards.Items.Add(card);

            _window.IsEnabled = true;
            this.Close();
        }
    }
}
