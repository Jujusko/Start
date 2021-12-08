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

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        private MainWindow _window;
        AllData Garb = AllData.GetInstance();
        public CreateCard(MainWindow window)
        {
            _window = window;
            InitializeComponent();
        }

        private void ButtonCreateCard_Click(object sender, RoutedEventArgs e)
        {
            RealCard tmp = new(Convert.ToInt32(TextBoxBalance.Text), TextBoxCardName.Text, Garb.user.Cards.Count);
            _window.userName.Cards.Add(tmp);
        }
    }
}
