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

namespace Contributions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contribution exCont;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlusContribution_Click(object sender, RoutedEventArgs e)
        {
            double summ = Convert.ToDouble(Summ.Text);
            double srok = Convert.ToDouble(TextBoxSrok.Text);
            double procent = Convert.ToDouble(Procent.Text);
            exCont = new(Name.Text, summ, Convert.ToString(DatePickerDate.SelectedDate), Convert.ToInt32(TextBoxSrok.Text), Convert.ToDouble(Procent.Text));
            // Ввод исходных данных в окно вкладов
            Contributions.Text = DatePickerDate.Text + " " + Name.Text + " " + Summ.Text + "руб " + TextBoxSrok.Text + "мес " + Procent.Text + "% " + Environment.NewLine;

        }

        private void GetTransaktion_Click(object sender, RoutedEventArgs e)
        {
            // Вычисление выражения

            // Ввод исходных данных в окно транзакций
            if (ContributionWithReplenishment.IsChecked == true)
            {
                Transaktions.Text = DateTransaktion.Text + " " + NameContribution.Text + " " + " " + "+" + SummToPopolnenie.Text + "руб "+ Environment.NewLine;
            }
            else
            {
                Transaktions.Text = DateTransaktion.Text + " " + NameContribution.Text + " " + "+" + SummToPopolnenie.Text + "руб " + "-" + SummToSnyatie.Text + "руб " + Environment.NewLine;
            }
        }

        private void ContributionWithReplenishment_Checked(object sender, RoutedEventArgs e)
        {
            LabelSumm.Visibility = Visibility.Visible;
            SummToPopolnenie.Visibility = Visibility.Visible;
        }

        private void ContributionWithReplenishmentAndWithdrawal_Checked(object sender, RoutedEventArgs e)
        {
            LabelSumm.Visibility = Visibility.Visible;
            SummToPopolnenie.Visibility = Visibility.Visible;
            LabelSummSnyatia.Visibility = Visibility.Visible;
            SummToSnyatie.Visibility = Visibility.Visible;

        }

    }
}
