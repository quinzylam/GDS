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
    public partial class ReadPage : ContentPage
    {
        private ReadViewModel _viewModel;

        public ReadPage()
        {
            InitializeComponent();
            InitializeViewModel();

            BindingContext = _viewModel;
        }

        private void InitializeViewModel()
        {
            _viewModel = AppFactory.GetInstance<ReadViewModel>();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }
}