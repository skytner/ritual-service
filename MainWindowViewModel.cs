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

        public ICommand NavigateToMainPageCommand { get; }
        public ICommand NavigateToServicesPageCommand { get; }
        public ICommand NavigateToContactsPageCommand { get; }
        public ICommand NavigateToAuthPageCommand { get; }
        public ICommand NavigateToMapPageCommand { get; }

        public MainWindowViewModel(Frame frame)
        {
            _frame = frame;
            NavigateToMainPageCommand = new RelayCommand(NavigateToMainPage);
            NavigateToServicesPageCommand = new RelayCommand(NavigateToServicesPage);
            NavigateToContactsPageCommand = new RelayCommand(NavigateToContactsPage);
            NavigateToAuthPageCommand = new RelayCommand(NavigateToAuthPage);
            NavigateToMapPageCommand = new RelayCommand(NavigateToMapPage);
        }

        private void NavigateToMainPage() => _frame.Navigate(new MainPage());
        private void NavigateToServicesPage() => _frame.Navigate(new ServicesPage());
        private void NavigateToContactsPage() => _frame.Navigate(new ContactsPage());
        private void NavigateToAuthPage() => _frame.Navigate(new AuthPage());
        private void NavigateToMapPage() => _frame.Navigate(new MapPage());
    }
}
