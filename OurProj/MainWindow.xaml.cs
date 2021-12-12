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
using Start;
using OurProj.PopupWindows;

namespace OurProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AllData AllInfo = AllData.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            ButtonInComboBoxForCards();
            ButtonInComboBoxForCategs();
            TabItemTranzactions.IsEnabled = false;
        }

        #region AddCard
        private void ButtonInComboBoxForCards()
        {
            Button add = new();
            add.Content = "New";
            add.Click += ButtonAddCard;
            ComboBoxCards.Items.Add(add);
        }

        private void ButtonAddCard(object sender, RoutedEventArgs e)
        {
            CreateCard toCreate = new(this);
            toCreate.Show();
            this.IsEnabled = false;
        }
        #endregion

        #region AddCateg
        private void ButtonInComboBoxForCategs()
        {
            Button add = new();
            add.Content = "New categ";
            add.Click += ButtonAddCateg;
            ComboBoxCategs.Items.Add(add);
        }
        private void ButtonAddCateg(object sender, RoutedEventArgs e)
        {
            WindowAddCategory toCreate = new(this);
            toCreate.Show();
            this.IsEnabled = false;
        }
        #endregion

        private void ButtonSelectUser_Click(object sender, RoutedEventArgs e)
        {

        }
        //del


        private void ComboBoxCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp;

            tmp = Convert.ToString(((Label)ComboBoxCards.SelectedItem).Content);
            RealCard card = AllInfo.user.GetActualCard(tmp);
            LabelCardName.Content = card.Name;
            LabelCardBalance.Content = card.Balance;
            TabItemTranzactions.IsEnabled = true;
        }


        public void ButtonTmp_Click(object sender, RoutedEventArgs e)
        {
            int i = -1;
            TextBoxTmp.Text = "";
            string ttmp = Convert.ToString(((Button)ComboBoxCategs.SelectedItem).Content);
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            StacPanelTranzactions.Children.Clear();
            while (++i < curCard.Tranzactions.Count)
            {
                if (curCard.Tranzactions[i].CatName == ttmp)
                {
                    Button tranz = new();
                    tranz.Content = curCard.Tranzactions[i].DateTranz + "\n" + curCard.Tranzactions[i].Sum + "\n";
                    if (curCard.Tranzactions[i].CashBack != 0)
                        tranz.Content += curCard.Tranzactions[i].CashBack +"";
                    tranz.Click += ForEveryTranzaction;
                    StacPanelTranzactions.Children.Add(tranz);
                    TextBoxTmp.Text += curCard.Tranzactions[i].DateTranz + "\n" + curCard.Tranzactions[i].Sum + "\n";
                }
            }
        }
        private void ForEveryTranzaction(object sender, RoutedEventArgs e)
        {
            string butinfo = Convert.ToString(((Button)sender).Content);
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            string categName = Convert.ToString(((Button)ComboBoxCategs.SelectedItem).Content);
            Tranz curTranz = Tranz.GetTranzaction(butinfo, categName);

            CorrectTranz win = new(this, curCard, curTranz);
            this.IsEnabled = false;
            win.Show();
            LabelCardName.Content = curCard.Name;
            LabelCardBalance.Content = curCard.Balance;
        }

        private void ButtonCrunhcForCashBack_Click(object sender, RoutedEventArgs e)
        {
            string catName;
            RealCard card = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            for (int i = 0; i < card.CashBacks.Count; i++)
            {
                Button newCateg = new();

                newCateg.Content = card.CashBacks[i].CatName;
                newCateg.Click += ButtonAddBought;
                ComboBoxCategs.Items.Add(newCateg);
                AllInfo.user.Categs.Add(card.CashBacks[i].CatName);
            }
        }
        private void ButtonAddBought(object sender, RoutedEventArgs e)
        {
            RealCard curCard = AllInfo.user.GetActualCard(Convert.ToString(LabelCardName.Content));
            string catName;

            catName = Convert.ToString(((Button)sender).Content);
            NewTranzaction addNew = new(this, catName, curCard);
            addNew.Show();
        }
    }
}
