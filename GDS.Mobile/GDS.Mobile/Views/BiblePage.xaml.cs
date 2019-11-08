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
    public partial class BiblePage : ContentPage
    {
        private BibleViewModel _viewModel;

        public BiblePage()
        {
            InitializeComponent();
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _viewModel = AppFactory.GetInstance<BibleViewModel>();

            Title = string.Concat(_viewModel.Book?.LongName, " ", _viewModel.Chapter?.Min(x => x.Chapter));
            BindingContext = _viewModel;
        }
    }
}