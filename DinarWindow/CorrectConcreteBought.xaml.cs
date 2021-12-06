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
using Start.Dinar;
using Start;

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для CorrectConcreteBought.xaml
    /// </summary>
    public partial class CorrectConcreteBought : Window
    {
        AllData Garb = AllData.GetInstance();
        private string Date;
        private int Sum;
        private WindowWithTabs _window;
        public CorrectConcreteBought(int sum, string date, WindowWithTabs win)
        {
            Sum = sum;
            Date = date;
            _window = win;
            InitializeComponent();
            TextBoxSum.Text = sum + "";
            DatePickerDateOfBought.Text = date;
        }

        private void ButtonAcceptCorrect_Click(object sender, RoutedEventArgs e)
        {
            string catName;

            catName = Convert.ToString(((Button)_window.ComboBoxCategs.SelectedItem).Content);
            _window.ChangeTranzaction(catName, Convert.ToInt32(TextBoxSum.Text),
                DatePickerDateOfBought.Text, 1, Sum, Date);
            this.Close();
        }

        private void ButtonDeleteTranzaction_Click(object sender, RoutedEventArgs e)
        {
            string catName;

            catName = Convert.ToString(((Button)_window.ComboBoxCategs.SelectedItem).Content);
            _window.ChangeTranzaction(catName, Convert.ToInt32(TextBoxSum.Text),
                DatePickerDateOfBought.Text, 0, Sum, Date);
            this.Close();
        }
    }
}
