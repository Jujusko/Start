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

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Window
    {
        private MainWindow _window;
        public UserCreate(MainWindow mainWindow)
        {
            InitializeComponent();
            _window = mainWindow;
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _window.Show();
            _window.IsEnabled = true;
        }

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            _window.userName.UserName = TextBoxUserName.Text;
            _window.userName.AddNewCard(TextBoxCardName.Text, Convert.ToInt32(TextBoxCardBalance.Text));
        }
    }
}
