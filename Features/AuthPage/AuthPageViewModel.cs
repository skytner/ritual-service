using Npgsql;
using System;
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

        // Конструктор принимает MainWindowViewModel
        public AuthPageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin()
        {
            // Проверка подключения к базе и вывод данных из таблицы TEST
            try
            {
                const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=KURSOVAIA";
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT AA FROM TEST";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            string data = "Данные из таблицы TEST:\n";
                            while (reader.Read())
                            {
                                data += $"{reader.GetString(0)}\n";
                            }
                            MessageBox.Show(data, "Проверка подключения");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка");
            }
        }


        private bool ValidateUser(string username, string password)
        {
            const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=KURSOVAIA";
            const string query = "SELECT password_hash = crypt(@password, password_hash) FROM users WHERE username = @username";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        var result = command.ExecuteScalar();
                        return result != null && (bool)result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
