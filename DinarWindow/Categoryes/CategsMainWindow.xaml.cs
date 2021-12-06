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
            CrunchForAdd();
        }

        private void CrunchForAdd()
        {
            Button tmpButton;

            tmpButton = new();
            tmpButton.Content = "Добавить";
            tmpButton.Click += ButtonAddCategory_Click;
            ComboBoxCategs.Items.Add(tmpButton);
        }
        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            AddByCategoryName tmp = new(this, Convert.ToString(((Button)sender).Content), userName.Cards[0].Balance);
            this.IsEnabled = false;
            tmp.Show();
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
                ComboBoxCategs.Items.Add(tmpButton);
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
        private void ButtonAdd_ComboBox_Click(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == ComboBoxCategs.Items[0])
            {
                ((Button)sender).Click += ButtonAddCategory_Click;
            }
        }
        }
}
