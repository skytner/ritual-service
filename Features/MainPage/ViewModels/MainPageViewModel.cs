using System.Windows.Input;
using YourNamespace.Commands;
using YourNamespace.ViewModels;

namespace RitualService.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public string WelcomeMessage { get; set; } =
            "Добро пожаловать на наш сайт ритуальных услуг!";

        public ICommand ShowServiceCommand { get; }

        public MainPageViewModel()
        {
            ShowServiceCommand = new RelayCommand(DisplayService);
        }

        private void DisplayService() { }
    }
}
