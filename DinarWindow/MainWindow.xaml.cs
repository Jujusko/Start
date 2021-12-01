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

namespace DinarWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Start.Dinar.Categories.Categories bla = new Start.Dinar.Categories.Categories();
        public Start.User userName = new("null");
        public MainWindow()
        {
            InitializeComponent();
            this.IsEnabled = false;
            UserCreate newUser = new(this);
            this.Hide();
            newUser.Show();
        }

        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            if (DateTranz.SelectedDate != null)
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, DateTranz.Text, Convert.ToInt32(TextBlockSumm.Text));
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text);
            }
            else
            {
                bla.NewOrAdd(TextBlockCategoryName.Text, null, Convert.ToInt32(TextBlockSumm.Text));
                TextBoxTest.Text = bla.GetInfoAboutBought(TextBlockCategoryName.Text) + "\n";
            }
        }

        private void ButtonAllBoughts_Click(object sender, RoutedEventArgs e)
        {
            TextBoxTest.Text = bla.PutToConsole(TextBoxChooseCategoryToSeeAll.Text);
        }

        public void CreateCategory(int sum, string name)
        {
            Button tmpButton;

            tmpButton = new();
            if (bla.NewOrAdd(name, null, sum) == 0)
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
        public void tmpButton_Click()
        {

        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Categs addCategory = new Categs(this);
            addCategory.Show();
            this.IsEnabled = false;
        }
        //TODO добавить список категорий
    }

}