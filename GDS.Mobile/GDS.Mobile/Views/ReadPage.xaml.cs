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

            Appearing += ReadPage_Appearing;

            BindingContext = _viewModel;
        }

        private void ReadPage_Appearing(object sender, EventArgs e)
        {
            _viewModel.LoadCommand.Execute(null);
        }

        private void InitializeViewModel()
        {
            _viewModel = AppFactory.GetInstance<ReadViewModel>();
            _viewModel.Navigate += ViewModel_Navigate;
        }

        private void ViewModel_Navigate(object sender, Events.NavigateEventArgs e)
        {
            switch (e.Focus)
            {
                case "Select":
                    this.Navigation.PushAsync(new BookSelectPage());
                    break;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }
}