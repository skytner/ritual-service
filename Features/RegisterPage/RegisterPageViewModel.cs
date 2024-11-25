using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using RitualService.Commands;

namespace RitualService.Features.AuthPage
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _confirmPassword;

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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }

        public ICommand RegisterCommand { get; }

        public RegisterPageViewModel()
        {
            RegisterCommand = new RelayCommand(ExecuteRegister);
        }

        private void ExecuteRegister()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка");
                return;
            }

            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка");
                return;
            }

            try
            {
                const string connectionString =
                    "Host=localhost;Port=5432;Username=postgres;Password=1;Database=KURSOVAIA";

                using (var connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query =
                        "INSERT INTO users (username, password_hash) VALUES (@username, crypt(@password, gen_salt('bf')))";

                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", Username);
                        command.Parameters.AddWithValue("@password", Password);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Регистрация прошла успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

     
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}