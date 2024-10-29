using System.Windows.Input;
using RitualService.Commands;
using RitualService.ViewModels;

namespace RitualService.Features.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {
        public string WelcomeMessage { get; set; } = "Добро пожаловать на наш сайт ритуальных услуг!";

        public ICommand NavigateToServicesCommand { get; }
        public ICommand NavigateToContactsCommand { get; }

        public MainPageViewModel()
        {
            NavigateToServicesCommand = new RelayCommand(NavigateToServices);
            NavigateToContactsCommand = new RelayCommand(NavigateToContacts);
        }

        private void NavigateToServices()
        {
        }

        private void NavigateToContacts()
        {
            
        }
    }
}
