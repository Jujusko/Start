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

        Start.Dinar.Categories.Categories bla = new Start.Dinar.Categories.Categories();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCategoryName_Click(object sender, RoutedEventArgs e)
        {
            string name;

            name = TextBlockCategoryName.Text;
        }

        private void ButtonDateByString_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonAddSum_Click(object sender, RoutedEventArgs e)
        {
            int summ;

            summ = Convert.ToInt32(TextBlockSumm.Text);
        }

        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;
            string dateToString;

            dateToString = today.Day + "/" + today.Month + "/" + today.Year;
            if (DateTranz.SelectedDate != null)
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, DateTranz.Text, Convert.ToInt32(TextBlockSumm.Text));
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text);
            }
            else
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, dateToString, Convert.ToInt32(TextBlockSumm.Text));
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text) + "\n";
            }
        }

        private void ButtonAllBoughts_Click(object sender, RoutedEventArgs e)
        {
            TextBoxTest.Text = bla.PutToConsole(TextBoxChooseCategoryToSeeAll.Text);
        }
        //TODO добавить список категорий
    }

}