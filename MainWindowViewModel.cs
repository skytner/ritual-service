using System.Windows.Controls;
using System.Windows.Input;
using RitualService.Features.MainPage;
using RitualService.Features.ServicesPage;
using RitualService.Features.ContactsPage;
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

        public MainWindowViewModel(Frame frame)
        {
            _frame = frame;
            NavigateToMainPageCommand = new RelayCommand(NavigateToMainPage);
            NavigateToServicesPageCommand = new RelayCommand(NavigateToServicesPage);
            NavigateToContactsPageCommand = new RelayCommand(NavigateToContactsPage);
        }

        private void NavigateToMainPage() => _frame.Navigate(new MainPage());
        private void NavigateToServicesPage() => _frame.Navigate(new ServicesPage());
        private void NavigateToContactsPage() => _frame.Navigate(new ContactsPage());
    }
}
