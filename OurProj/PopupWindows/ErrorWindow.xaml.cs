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
using OurProj;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    
    public partial class ErrorWindow : Window
    {
        private MainWindow _win;
        public ErrorWindow(MainWindow win)
        {
            InitializeComponent();
            _win = win;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            _win.IsEnabled = true;
            _win.Show();
            this.Close();
        }
    }
}
