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
using Start.Dinar;

namespace DinarWindow
{
    /// <summary>
    /// Логика взаимодействия для Categs.xaml
    /// </summary>
    public partial class Categs : Window
    {
        private CategsMainWindow _window;
        private WindowWithTabs _awin;
        public Categs(CategsMainWindow mainWindow)
        {
            _window = mainWindow;
            _awin = null;
            InitializeComponent();
        }

        public Categs(WindowWithTabs mainWindow)
        {
            _awin = mainWindow;
            _window = null;
            InitializeComponent();
        }
        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.CreateCategory(Convert.ToInt32((TextBoxSum.Text)),
                    TextBoxCategoryName.Text, _window.userName.Cards[0].Balance);
                _window.IsEnabled = true;
                this.Close();
            }
            else
            {
                _awin.CreateCategory(Convert.ToInt32((TextBoxSum.Text)),
                    TextBoxCategoryName.Text, _awin._window.userName.Cards[0].Balance);
                _awin.IsEnabled = true;
                this.Close();
            }
        }

        private void TextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
