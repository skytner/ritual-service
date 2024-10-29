using System.Windows.Controls;

namespace RitualService.Features.MainPage
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
