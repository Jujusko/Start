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
        AllData Garb = AllData.GetInstance();
        public User userName = new User("null");
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            WindowWithTabs aaa = new();

            aaa.Show();
            this.Close();
            Garb.user.UserName = TextBoxUserName.Text;
            Garb.user.bla = new();
        }
    }
    //TODO добавить список категорий
}