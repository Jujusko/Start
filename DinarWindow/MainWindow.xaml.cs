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

namespace DinarWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Start.Dinar.Categories.Categories bla = new Start.Dinar.Categories.Categories();
        public Start.User userName = new Start.User("null");
        public MainWindow()
        {
            InitializeComponent();
            UserCreate newUser = new(this);
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            CategsMainWindow categs = new(this);
            categs.Show();
            this.Close();
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            int last;

            userName.UserName = TextBoxUserName.Text;
            userName.AddNewCard(TextBoxCardName.Text, Convert.ToInt32(TextBoxCardBalance.Text));

            //last = userName.Len;
            //userName.UserName = TextBoxUserName.Text;
            //userName.AddNewCard(TextBoxCardName.Text, Convert.ToInt32(TextBoxCardBalance.Text));
            //TextBoxTest.Text += userName.Cards[last].Name + "\n";
            //TextBoxTest.Text += userName.Cards[last].Balance;
            //ButtonAccept.IsEnabled = true;
        }
    }
    //TODO добавить список категорий
}

