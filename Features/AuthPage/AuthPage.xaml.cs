using System.Windows.Controls;

namespace RitualService.Features.AuthPage
{
    public partial class AuthPage : Page
    {
        public AuthPage(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = new AuthPageViewModel(mainWindowViewModel);
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is AuthPageViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
