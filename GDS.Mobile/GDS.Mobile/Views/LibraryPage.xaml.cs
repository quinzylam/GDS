using GDS.Mobile.Commands;
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
    public partial class LibraryPage : ContentPage
    {
        private LibraryViewModel _viewModel;

        public LibraryPage()
        {
            InitializeComponent();
            InitializeViewModel();

            Appearing += LibraryPage_Appearing;
            BindingContext = _viewModel;
        }

        private void LibraryPage_Appearing(object sender, EventArgs e)
        {
            _viewModel.LoadCommand.Execute(null);
        }

        private void InitializeViewModel()
        {
            _viewModel = AppFactory.GetInstance<LibraryViewModel>();
        }
    }
}