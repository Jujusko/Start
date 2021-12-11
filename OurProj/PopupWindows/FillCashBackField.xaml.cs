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
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            CashBackByCategory newCB = new(TextBoxCatName.Text, Convert.ToInt32(TextBoxPercent.Text));
            CurCard.CashBacks.Add(newCB);
        }
    }
}
