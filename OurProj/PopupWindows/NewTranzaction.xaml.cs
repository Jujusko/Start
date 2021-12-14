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
using Start;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для NewTranzaction.xaml
    /// </summary>
    public partial class NewTranzaction : Window
    {
        private AllData Data = AllData.GetInstance();
        private MainWindow _window { get; set; }
        private string category;
        private RealCard curCard { get; set; }
        public NewTranzaction(MainWindow window, string category, RealCard curCard)
        {
            InitializeComponent();
            _window = window;
            this.category = category;
            this.curCard = curCard;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime dayOfBought;
            int sum;
            Tranz newTranz;
            ErrorWindow err = new(_window);

            sum = Convert.ToInt32(TextBoxSum.Text);
            if (DatePickerBoughtDay.SelectedDate != null)
                dayOfBought = (DateTime)DatePickerBoughtDay.SelectedDate;
            else
                dayOfBought = DateTime.Today;
            newTranz = new(dayOfBought, category, sum);

            if (curCard.ChangeBalanceMinus(sum) == -1)
                err.Show();
            else
            {
                curCard.Tranzactions.Add(newTranz);
                TryCashBack(curCard, newTranz);
                Data.user.tranzactions.Add(newTranz);
                _window.ChangeLabelInfo();
            }

            _window.LabelCardBalance.Content = curCard.Balance;
            _window.IsEnabled = true;
            this.Close();
        }
        private void TryCashBack(RealCard curCard, Tranz newTranz)
        {
            int profit = 0;
            for (int i = 0; i < curCard.CashBacks.Count; i++)
            {
                if (curCard.CashBacks[i].CatName == newTranz.CatName)
                {
                    profit = newTranz.Sum * curCard.CashBacks[i].Percent / 100;
                    newTranz.CashBack = profit;
                    curCard.AccumulatedCashback += profit;
                }
            }
            return ;
        }

        private void TextBoxSum_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Char)e.Key >= 34 && (Char)e.Key <= 43))
            {
                e.Handled = false;
            }
            else if (((Char)e.Key >= 74 && (Char)e.Key <= 83))
            {
                e.Handled = false;
            }
            else if ((Char)e.Key == 2)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
