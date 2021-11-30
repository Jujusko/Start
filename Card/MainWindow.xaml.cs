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

namespace Card
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeBalance_Click(object sender, RoutedEventArgs e)
        {
            Balance.Text = Balance.Text + Summ.Text;
        }

        private void Balance_TextChanged(object sender, TextChangedEventArgs e)
        {
            char lastChar = Balance.Text[Balance.Text.Length - 1];
            if (!Char.IsDigit(lastChar) && lastChar != ',')
            {
                Balance.Text = Balance.Text.Remove(Balance.Text.Length - 1);
                Balance.CaretIndex = Balance.Text.Length;
            }
        }

        private void Summ_TextChanged(object sender, TextChangedEventArgs e)
        {
            char lastChar = Summ.Text[Summ.Text.Length - 1];
            if (!Char.IsDigit(lastChar) && lastChar != ',')
            {
                Summ.Text = Summ.Text.Remove(Summ.Text.Length - 1);
                Summ.CaretIndex = Summ.Text.Length;
            }
        }
    }
}
