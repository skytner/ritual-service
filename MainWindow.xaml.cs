using System.Windows;

namespace RitualService
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.MainPage());
        }
    }
}
