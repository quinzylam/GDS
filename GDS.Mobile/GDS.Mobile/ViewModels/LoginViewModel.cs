using GDS.Core.Infrastructure.Utils;
using GDS.Mobile.Commands;
using GDS.Mobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using GDS.Resources;
using GDS.Core.Models.Administration;
using GDS.Core.Services;
using System;
using System.Security.Authentication;

namespace GDS.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private readonly ISecurityService<User> _securityService;

        public LoginViewModel(ISecurityService<User> securityService)
        {
            Title = GDSResource.LoginTitle;
            _securityService = securityService;
            GetUserCommand = new AsyncCommand(GetUser, Watcher, CanGetUser);
            LoginCommand = new AsyncCommand(Login, Watcher, CanLogin);
            RefreshCommand = new Command(Refresh);
        }

        private void Refresh()
        {
            (LoginCommand as Command).ChangeCanExecute();
        }

        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }

        public IAsyncCommand GetUserCommand { get; private set; }
        public IAsyncCommand LoginCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public delegate void OnLoginEventHandler(object sender, EventArgs e);

        public event OnLoginEventHandler OnLogin;

        public bool CanGetUser()
        {
            if (IsBusy) return false;

            if (string.IsNullOrEmpty(Username)) return HandleError(string.Concat(nameof(Username), GDSResource.EmptyError));

            return true;
        }

        public bool CanLogin()
        {
            if (IsBusy) return false;

            if (string.IsNullOrEmpty(Password)) return HandleError(string.Concat(nameof(Password), GDSResource.EmptyError));

            if (_securityService.User == null)
                return HandleError(string.Concat(nameof(User), GDSResource.ExistError));

            return true;
        }

        public async Task GetUser() => await _securityService.GetUserAsync(Username);

        public async Task Login()
        {
            if (await _securityService.LoginAsync(Password))
                OnLogin?.Invoke(this, new EventArgs());
        }
    }
}