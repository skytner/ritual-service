using System.Windows;

namespace RitualService
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainWindowViewModel(MainFrame);
            DataContext = mainViewModel;
        }
    }
}
