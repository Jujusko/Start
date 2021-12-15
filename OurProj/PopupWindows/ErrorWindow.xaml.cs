using System.Windows;

namespace OurProj.PopupWindows
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>

    public partial class ErrorWindow : Window
    {
        private MainWindow _win;
        public ErrorWindow(MainWindow win)
        {
            InitializeComponent();
            _win = win;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            _win.IsEnabled = true;
            _win.Show();
            this.Close();
        }
    }
}
