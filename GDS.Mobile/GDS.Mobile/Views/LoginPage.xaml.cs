using GDS.Mobile.Factories;
using GDS.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GDS.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            InitializeViewModel();
        }

        public void InitializeViewModel()
        {
            _viewModel = AppFactory.GetInstance<LoginViewModel>();
            _viewModel.OnLogin += ViewModel_OnLogin;

            BindingContext = _viewModel;
        }

        private void ViewModel_OnLogin(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}