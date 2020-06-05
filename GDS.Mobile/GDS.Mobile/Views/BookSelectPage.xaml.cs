﻿using GDS.Core.Models;
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
    public partial class BookSelectPage : ContentPage
    {
        private BookSelectViewModel viewModel;

        public BookSelectPage()
        {
            InitializeComponent();
            InitializeViewModel();

            Appearing += SelectPage_Appearing;
            BindingContext = viewModel;
        }

        private void SelectPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadCommand.Execute(null);
        }

        private void InitializeViewModel()
        {
            viewModel = AppFactory.GetInstance<BookSelectViewModel>();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel.SelectCommand.Execute(e.SelectedItem);
            var book = (Book)e.SelectedItem;
            await this.Navigation.PushAsync(new ChapterSelectPage(book.BibleBooks.FirstOrDefault().Num));
        }
    }
}