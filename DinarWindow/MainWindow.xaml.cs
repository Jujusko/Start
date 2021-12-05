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
using Start.Dinar.Categories;
using Start;

namespace DinarWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public Categories bla = new Start.Dinar.Categories.Categories();
        public User userName = new Start.User("null");
        public MainWindow()
        {
            InitializeComponent();
            UserCreate newUser = new(this);
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            WindowWithTabs aaa = new(this);
            aaa.Show();
            this.Close();
            userName.bla = new();
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            userName.UserName = TextBoxUserName.Text;
        }
    }
    //TODO добавить список категорий
}

