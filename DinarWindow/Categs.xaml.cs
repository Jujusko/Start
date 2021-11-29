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
        public Categs()
        {
            InitializeComponent();
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Start.Dinar.Categories.Categories cats = new();
            //cats.NewCategory("Еда", 300, DateT);
            NodeContent.Text = "qweqweqweqwe";
        }

        private void TextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
