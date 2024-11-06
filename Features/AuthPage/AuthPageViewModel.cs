using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using RitualService.Commands;

namespace RitualService.Features.AuthPage
{
    public class AuthPageViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand LoginCommand { get; }

        // Изменение конструктора для принятия MainWindowViewModel
        public AuthPageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin()
        {
            // Простая логика авторизации для демонстрации
            if (Username == "admin" && Password == "password")
            {
                MessageBox.Show("Вход выполнен!");

                // Уведомляем MainWindowViewModel об успешной авторизации
                _mainWindowViewModel.SetUserAuthenticated(true);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
