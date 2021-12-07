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
    /// Логика взаимодействия для Categs.xaml
    /// </summary>
    public partial class Categs : Window
    {
        private WindowWithTabs _awin;
        public AllData Garb = AllData.GetInstance();


        public Categs(WindowWithTabs mainWindow)
        {
            _awin = mainWindow;
            InitializeComponent();
        }
        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            string date;

            date = DatePickerTranzDay.Text;
            RealCard tmp = Garb.user.GetActualCard(Convert.ToString(_awin.Label2.Content));
            _awin.CreateCategory(Convert.ToInt32((TextBoxSum.Text)), TextBoxCategoryName.Text, tmp.Balance, date);
            _awin.IsEnabled = true;
            this.Close();
        }

        private void TextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
