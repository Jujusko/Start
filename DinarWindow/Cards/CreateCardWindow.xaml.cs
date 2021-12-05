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

namespace DinarWindow.Cards
{
    /// <summary>
    /// Логика взаимодействия для CreateCardWindow.xaml
    /// </summary>
    public partial class CreateCardWindow : Window
    {
        private MainWindow _window;
        private WindowWithTabs _a;

        public CreateCardWindow(MainWindow window, WindowWithTabs a)
        {
            _window = window;
            _a = a;
            InitializeComponent();
        }

        private void TextBoxNameCard_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            _a.CreateCard(TextBoxNameCard.Text, Convert.ToInt32(TextBoxBalance.Text));
            _a.IsEnabled = true;
            this.Close();
        }
    }
}
