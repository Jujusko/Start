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
using DinarWindow;
using Project;

namespace Project.UtilWindows
{
    /// <summary>
    /// Логика взаимодействия для DeclineTranz.xaml
    /// </summary>
    public partial class DeclineTranz : Window
    {
        WindowWithTabs _window;
        public DeclineTranz(WindowWithTabs sd)
        {
            _window = sd;
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            _window.IsEnabled = true;
            this.Close();
        }
    }
}
