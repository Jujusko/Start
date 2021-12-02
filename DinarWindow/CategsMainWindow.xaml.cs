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
    /// Логика взаимодействия для CategsMainWindow.xaml
    /// </summary>
    public partial class CategsMainWindow : Window
    {
        public Start.Dinar.Categories.Categories bla;
        public Start.User userName;
        public CategsMainWindow(MainWindow windowUser)
        {
            bla = windowUser.bla;
            userName = windowUser.userName;
            InitializeComponent();
        }
        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            if (DateTranz.SelectedDate != null)
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, DateTranz.Text, Convert.ToInt32(TextBlockSumm.Text), userName.Cards[0].Balance);
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text);
            }
            else
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, null, Convert.ToInt32(TextBlockSumm.Text), userName.Cards[0].Balance);
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text) + "\n";
            }
        }

        private void ButtonAllBoughts_Click(object sender, RoutedEventArgs e)
        {
            TextBoxTest.Text = bla.PutToConsole(TextBoxChooseCategoryToSeeAll.Text);
        }

        public void CreateCategory(int sum, string name, int balance)
        {
            Button tmpButton;

            tmpButton = new();
            if (bla.NewOrAdd(name, null, sum, balance) == 0)
            {
                StacPanelCategs.Children.Add(tmpButton);
                tmpButton.Content = name;
                //tmpButton.Click += new EventHandler(tmpButton_Click());
            }
            else
            {

            }
            TextBoxTest.Text = name;
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Categs addCategory = new Categs(this);
            addCategory.Show();
            this.IsEnabled = false;
        }

        private void ComboBoxCards_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            Button newB = new();

            newB.Content = "Cards";
            ComboBoxCards.Items.Add(new Button());
        }
        //TODO добавить список категорий
    }
}
