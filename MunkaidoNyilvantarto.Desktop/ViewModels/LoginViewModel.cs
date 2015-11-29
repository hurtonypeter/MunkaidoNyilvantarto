using MunkaidoNyilvantarto.Desktop.Services;
using MunkaidoNyilvantarto.Desktop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MunkaidoNyilvantarto.Desktop.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private DataService service = new DataService();

        private LoginWindow currentWindow;

        private string _userName;

        public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged(); } }

        private bool _isProgressing = false;

        public bool IsProgressing { get { return _isProgressing; } set { _isProgressing = value; OnPropertyChanged(); OnPropertyChanged("IsNotProgressing"); OnPropertyChanged("IsProgressingVisibility"); } }

        public bool IsNotProgressing { get { return !IsProgressing; } }

        public string IsProgressingVisibility { get { return IsProgressing ? "Visible" : "Hidden"; } }

        private string _errorMassage;

        public string ErrorMessage { get { return _errorMassage; } set { _errorMassage = value; OnPropertyChanged(); } }

        public LoginViewModel(LoginWindow window)
        {
            currentWindow = window;
        }

        private ICommand _loginCommand;

        public ICommand LoginCommand {
            get
            {
                if(_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(Login);
                }

                return _loginCommand;
            }
        }

        private async void Login(object o)
        {
            var Password = ((PasswordBox)o).Password;

            ErrorMessage = null;

            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "A felhasználónév vagy a jelszó üres";
            }
            else
            {
                IsProgressing = true;

                try
                {
                    var result = await service.Login(UserName, Password);
                    if (result.Succeeded)
                    {
                        var mainWindow = new WorkerWindow();
                        mainWindow.Show();
                        currentWindow.Close();
                    }
                    else
                    {
                        ErrorMessage = string.Join("\n",result.Errors.Select(k => k.Value));
                    }
                }
                catch (Exception)
                {
                    ErrorMessage = "Hiba történt a bejelentkezés során";
                }

                IsProgressing = false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
