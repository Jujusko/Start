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
    /// Логика взаимодействия для CorrectTranz.xaml
    /// </summary>
    

    public partial class CorrectTranz : Window
    {
        private MainWindow _win { get; set; }
        private string _catName { get; set; }
        private RealCard _card { get; set; }
        private int prevSum { get; set; }
        private DateTime prevDate { get; set; }
        private AllData Data = AllData.GetInstance();
        public CorrectTranz(MainWindow window, RealCard card, Tranz curTranz)
        {
            InitializeComponent();
            _win = window;
            _catName = curTranz.CatName;
            _card = card;
            prevDate = curTranz.DateTranz;
            prevSum = curTranz.Sum;
        }

        private void ButtonChangeTranz_Click(object sender, RoutedEventArgs e)
        {
            Tranz thisTranz = new(prevDate, _catName, prevSum);
            int newSum;
            ErrorWindow err = new(_win);

            newSum = Convert.ToInt32(TextBoxSum.Text);
            for (int i = 0; i < _card.Tranzactions.Count; i++)
            {
                if (thisTranz.Equals(_card.Tranzactions[i]))
                {
                    if (_card.Balance + prevSum >= newSum)
                    {
                        _card.Tranzactions[i].DateTranz = DatePickerDateOfBought.DisplayDate;
                        _card.Tranzactions[i].Sum = newSum;
                        _card.ChangeBalancePlus(prevSum);
                        _card.ChangeBalanceMinus(newSum);
                        _win.IsEnabled = true;
                        _win.LabelCardBalance.Content = _card.Balance;
                        _win.ButtonTmp_Click(sender, e);
                        this.Close();
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            err.Show();
            this.Close();
        }

        private void ButtonTmp_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonDeleteTranz_Click(object sender, RoutedEventArgs e)
        {
            Tranz thisTranz = new(prevDate, _catName, prevSum);
            int newSum;
            ErrorWindow err = new(_win);

            for (int i = 0; i < _card.Tranzactions.Count; i++)
            {
                if (thisTranz.Equals(_card.Tranzactions[i]))
                {
                    _card.Tranzactions.RemoveAt(i);
                    _win.IsEnabled = true;
                    _card.ChangeBalancePlus(thisTranz.Sum);
                    _win.LabelCardBalance.Content = _card.Balance;
                    _win.IsEnabled = true;
                    _win.ButtonTmp_Click(sender, e);
                    this.Close();
                }
            }
        }
        /*
* DateTime dayOfBought;
   int sum;
   Tranz newTranz;
   ErrorWindow err = new(_window);

   sum = Convert.ToInt32(TextBoxSum.Text);
   dayOfBought = DatePickerBoughtDay.DisplayDate;
   newTranz = new(dayOfBought, category, sum);

   if (curCard.ChangeBalanceMinus(sum) == -1)
       err.Show();
   else
   {
       curCard.Tranzactions.Add(newTranz);
   }

   _window.LabelCardBalance.Content = curCard.Balance;
   _window.IsEnabled = true;
   this.Close();
* */
    }
}
