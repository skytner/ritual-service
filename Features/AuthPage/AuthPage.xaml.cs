using System.Windows.Controls;

namespace RitualService.Features.AuthPage
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            DataContext = new AuthPageViewModel();
        }
    }
}
