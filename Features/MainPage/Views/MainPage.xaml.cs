using System.Windows.Controls;
using RitualService.ViewModels;

namespace RitualService.Views
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
