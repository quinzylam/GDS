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
        private readonly LoginViewModel _viewModel;

        public LoginPage()
        {
            _viewModel = AppFactory.GetInstance<LoginViewModel>();
            _viewModel.IsBusy = true;
            InitializeComponent();
            BindingContext = _viewModel;
            _viewModel.IsBusy = false;
        }
    }
}