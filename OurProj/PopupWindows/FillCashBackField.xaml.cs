using Start;
using System;
using System.Windows;
using System.Windows.Input;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для FillCashBackField.xaml
    /// </summary>
    public partial class FillCashBackField : Window
    {
        private MainWindow _window;
        private AllData Data = AllData.GetInstance();
        private RealCard CurCard { get; set; }
        public FillCashBackField(MainWindow window, RealCard card)
        {
            InitializeComponent();
            _window = window;
            CurCard = card;
            TextBoxPercent.Text = "";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            CashBackByCategory newCB = new(TextBoxCatName.Text, Convert.ToInt32(TextBoxPercent.Text));
            CurCard.CashBacks.Add(newCB);
            DateTime today = DateTime.Now;
            if (DatePickerLastCashBack.SelectedDate != null)
            {
                if (today.CompareTo(DatePickerLastCashBack.SelectedDate) < 0)
                {
                    MessageBox.Show("Bad data");
                    CurCard.CashBackProfit = today.AddMonths(1);
                }
                else
                {
                    CurCard.CashBackProfit = (DateTime)DatePickerLastCashBack.SelectedDate;
                    CurCard.CashBackProfit.AddMonths(1);
                }
            }
            else
            {
                CurCard.CashBackProfit = (DateTime)DatePickerLastCashBack.SelectedDate;
                CurCard.CashBackProfit.AddMonths(1);
            }
            this.Close();
        }

        private void TextBoxPercent_KeyDown(object sender, KeyEventArgs e)
        {
            int c = (Char)e.Key;
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
