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
        public Start.User userName;
        private MainWindow _window;
        public CategsMainWindow(MainWindow windowUser)
        {

            userName = windowUser.userName;
            InitializeComponent();
        }
        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            AddByCategoryName tmp = new(this, Convert.ToString(((Button)sender).Content), userName.Cards[0].Balance);
            this.IsEnabled = false;
            tmp.Show();
            //if (DateTranz.SelectedDate != null)
            //{
            //    userName.bla.NewOrAdd(TextBlockCategoryName.Text, DateTranz.Text, Convert.ToInt32(TextBlockSumm.Text), userName.Cards[0].Balance);
            //    TextBoxTest.Text = userName.bla.GetInfoAboutBought(TextBlockCategoryName.Text);
            //}
            //else
            //{
            //    if (userName.bla.NewOrAdd(TextBlockCategoryName.Text, 
            //        null, Convert.ToInt32(TextBlockSumm.Text), userName.Cards[0].Balance) == 0)
            //    {
            //        Button tmpButton = new();
            //        ComboBoxCards.Items.Add(tmpButton);
            //        tmpButton.Content = TextBlockCategoryName.Text;
            //        tmpButton.Click += ChildrenButton;
            //    }
            //    TextBoxTest.Text = userName.bla.GetInfoAboutBought(TextBlockCategoryName.Text) + "\n";
            //}
        }

        private void ChildrenButton(object sender, RoutedEventArgs e)
        {
            string name;

             name = Convert.ToString(((Button)sender).Content);
           // bla.NewOrAdd(name, null, Convert.ToInt32(TextBlockSumm.Text), userName.);
        }
        private void AddCategoryCBox(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAllBoughts_Click(object sender, RoutedEventArgs e)
        {
            TextBoxTest.Text = userName.bla.PutToConsole(TextBoxChooseCategoryToSeeAll.Text);
        }

        public void CreateCategory(int sum, string name, int balance)
        {
            Button tmpButton;
            int res;

            
            tmpButton = new();
            res = userName.bla.NewOrAdd(name, null, sum, balance);
            if (res == 0)
            {
                tmpButton.Content = name;
                tmpButton.Click += ButtonAddData_Click;
                ComboBoxCards.Items.Add(tmpButton);
            }
            else if (res == -1)
            {
                return;
            }
            TextBoxTest.Text = name;
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Categs addCategory = new Categs(this);
            addCategory.Show();
            this.IsEnabled = false;
        }
    }
}
