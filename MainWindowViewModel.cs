using System.Windows.Controls;
using System.Windows.Input;
using RitualService.Features.MainPage;
using RitualService.Features.ServicesPage;
using RitualService.Features.ContactsPage;
using RitualService.Features.AuthPage;
using RitualService.Features.MapPage;
using RitualService.Commands;
using RitualService.ViewModels;

namespace RitualService
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly Frame _frame;
        private bool _isUserAuthenticated;

        public bool IsUserAuthenticated
        {
            get => _isUserAuthenticated;
            set
            {
                if (_isUserAuthenticated != value)
                {
                    _isUserAuthenticated = value;
                    OnPropertyChanged(nameof(IsUserAuthenticated));
                }
            }
        }

        public ICommand NavigateToMainPageCommand { get; }
        public ICommand NavigateToServicesPageCommand { get; }
        public ICommand NavigateToContactsPageCommand { get; }
        public ICommand NavigateToAuthPageCommand { get; }
        public ICommand NavigateToMapPageCommand { get; }
        public ICommand NavigateToRegisterPageCommand { get; }
        public MainWindowViewModel(Frame frame)
        {
            _frame = frame;
            NavigateToMainPageCommand = new RelayCommand(NavigateToMainPage);
            NavigateToServicesPageCommand = new RelayCommand(NavigateToServicesPage);
            NavigateToContactsPageCommand = new RelayCommand(NavigateToContactsPage);
            NavigateToAuthPageCommand = new RelayCommand(NavigateToAuthPage);
            NavigateToMapPageCommand = new RelayCommand(NavigateToMapPage);
            NavigateToRegisterPageCommand = new RelayCommand(NavigateToRegisterPage);

            // Изначально пользователь не авторизован
            IsUserAuthenticated = false;
        }

        private void NavigateToMainPage() => _frame.Navigate(new MainPage());
        private void NavigateToServicesPage() => _frame.Navigate(new ServicesPage());
        private void NavigateToContactsPage() => _frame.Navigate(new ContactsPage());
        private void NavigateToAuthPage() => _frame.Navigate(new AuthPage(this));
        private void NavigateToRegisterPage() => _frame.Navigate(new RegisterPage());

        public void SetUserAuthenticated(bool isAuthenticated)
        {
            IsUserAuthenticated = isAuthenticated;
            if (isAuthenticated)
            {
                NavigateToMainPage(); // Перенаправление на главную страницу
            }
        }

        private void NavigateToMapPage() => _frame.Navigate(new MapPage());
    }
}
