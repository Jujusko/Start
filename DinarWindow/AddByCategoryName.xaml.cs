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

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для AddByCategoryName.xaml
    /// </summary>
    public partial class AddByCategoryName : Window
    {
        private MainWindow _window;
        public AddByCategoryName(MainWindow window)
        {
            _window = window;
            InitializeComponent();
        }
    }
}
