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
    /// Логика взаимодействия для WindowAddCategory.xaml
    /// </summary>
    public partial class WindowAddCategory : Window
    {
        private MainWindow _window;
        private AllData Data = AllData.GetInstance();
        public WindowAddCategory(MainWindow window)
        {
            _window = window;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Button newCateg = new();

            newCateg.Content = TextBoxCatName.Text;
            newCateg.Click += ButtonAddBought;
            _window.ComboBoxCategs.Items.Add(newCateg);

            Data.user.Categs.Add(TextBoxCatName.Text);
            _window.IsEnabled = true;
            this.Close();
        }
        private void ButtonAddBought(object sender, RoutedEventArgs e)
        {
            RealCard curCard = Data.user.GetActualCard(Convert.ToString(_window.LabelCardName.Content));
            string catName;

            catName = Convert.ToString(((Button)sender).Content);
            NewTranzaction addNew = new(_window, catName, curCard);
            addNew.Show();
        }
    }
}
