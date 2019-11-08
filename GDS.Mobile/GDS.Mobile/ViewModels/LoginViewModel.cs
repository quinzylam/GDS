using GDS.Core.Infrastructure.Utils;
using GDS.Core.Models.System;
using GDS.Mobile.Commands;
using GDS.Mobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GDS.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private User user;

        public LoginViewModel()
        {
            GetUserCommand = new AsyncCommand(GetUser, CanGetUser, Watcher);
            LoginCommand = new Command(Login, CanLogin);
            RefreshCommand = new Command(Refresh);
        }

        private void Refresh()
        {
            (LoginCommand as Command).ChangeCanExecute();
        }

        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public IAsyncCommand GetUserCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public User User { get => user; set => SetProperty(ref user, value); }

        public bool CanGetUser(object arg)
        {
            if (IsBusy) return false;

            if (string.IsNullOrEmpty(Username)) return HandleError("Username cannot be empty.");

            return true;
        }

        public bool CanLogin(object arg)
        {
            if (IsBusy) return false;

            if (string.IsNullOrEmpty(Password)) return HandleError("Password cannot be empty.");

            if (User == null)
                return HandleError("User does not exist");

            if (!new PasswordProvider().IsValid(Password, User.Password))
                return HandleError("Password is invalid");

            return true;
        }

        public async Task GetUser(object arg)
        {
            User = await DataStore.GetUserAsync(Username);
        }

        public static void Login(object arg)
        {
            App.IsUserLoggedIn = true;
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}