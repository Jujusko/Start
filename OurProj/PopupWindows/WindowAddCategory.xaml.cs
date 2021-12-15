using Start;
using System;
using System.Windows;
using System.Windows.Controls;

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
            int flag = 1;

            newCateg.Content = TextBoxCatName.Text;
            newCateg.Click += ButtonAddBought;
            foreach (Button temp in _window.ComboBoxCategs.Items)
            {
                if (Convert.ToString(temp.Content) == Convert.ToString(newCateg.Content))
                {
                    flag = 0;
                    break;
                }
            }
            if (flag != 0)
            {
                _window.ComboBoxCategs.Items.Add(newCateg);

                Data.user.Categs.Add(TextBoxCatName.Text);
            }
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
