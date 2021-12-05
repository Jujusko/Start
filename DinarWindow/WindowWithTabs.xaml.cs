using System;
using DinarWindow.Cards;
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
    /// Логика взаимодействия для WindowWithTabs.xaml
    /// </summary>
    public partial class WindowWithTabs : Window
    {
        public MainWindow _window;
        public WindowWithTabs(MainWindow window)
        {
            _window = window;
            InitializeComponent();
            CrunchForAddCard();
            CrunchForAddCategs();
        }

        private void CrunchForAddCard()
        {
            Button tmpButton;

            tmpButton = new();
            tmpButton.Content = "Добавить карту";
            tmpButton.Click += ButtonAddCard_Click;
            ComboBoxCards.Items.Add(tmpButton);
        }
        private void CrunchForAddCategs()
        {
            Button tmpButton;

            tmpButton = new();
            tmpButton.Content = "Добавить";
            tmpButton.Click += ButtonAddCategory_Click;
            ComboBoxCategs.Items.Add(tmpButton);
        }
        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            Categs addCategory = new Categs(this);
            addCategory.Show();
            this.IsEnabled = false;
        }
        private void ButtonAddData_Click(object sender, RoutedEventArgs e)
        {
            AddByCategoryName tmp = new(this, Convert.ToString(((Button)sender).Content), _window.userName.Cards[0].Balance);
            this.IsEnabled = false;
            tmp.Show();
        }


        public void CreateCategory(int sum, string name, int balance)
        {
            Button tmpButton;
            int res;


            tmpButton = new();
            res = _window.userName.bla.NewOrAdd(name, null, sum, balance);
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

        private void ButtonAddCard_Click(object sender, RoutedEventArgs e)
        {
            CreateCardWindow add = new CreateCardWindow(_window, this);
            add.Show();
            this.IsEnabled = false;
        }

        public void CreateCard(string cardName, int balance)
        {
            Label tmp = new();

            tmp.Content = cardName;
            _window.userName.AddNewCard(cardName, balance);
            ComboBoxCards.Items.Add(tmp);
        }
    }
}
