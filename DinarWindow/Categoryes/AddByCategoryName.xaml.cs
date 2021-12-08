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
    /// Логика взаимодействия для AddByCategoryName.xaml
    /// </summary>
    public partial class AddByCategoryName : Window
    {
        private WindowWithTabs _wwindow;
        private int _balance;
        private string _catName;

        public AddByCategoryName(WindowWithTabs window, string name, int balance)
        {
            _wwindow = window;
            _balance = balance;
            _catName = name;
            InitializeComponent();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string date;

            date = DatePickerTranzDay.Text;

            this.Close();
            _wwindow.IsEnabled = true;
            _wwindow.CreateCategory(Convert.ToInt32(TextBoxSum.Text), _catName, _balance, date);
        }
    }
}
