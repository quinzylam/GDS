using GDS.Mobile.Factories;
using GDS.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GDS.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterSelectPage : ContentPage
    {
        private ChapterSelectViewModel viewModel;

        public ChapterSelectPage(int chapterNo)
        {
            InitializeComponent();
            InitializeViewModel(chapterNo);
        }

        private void InitializeViewModel(int chapterNo)
        {
            viewModel = AppFactory.GetInstance<ChapterSelectViewModel>();
            viewModel.LoadCommand.Execute(chapterNo);
            BindingContext = viewModel;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel.SelectCommand.Execute(e.SelectedItem);
            await this.Navigation.PopToRootAsync();
        }
    }
}