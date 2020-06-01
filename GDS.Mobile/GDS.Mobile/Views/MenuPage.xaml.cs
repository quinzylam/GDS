using GDS.Mobile.Factories;
using GDS.Mobile.Models;
using GDS.Mobile.Models.Enums;
using GDS.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GDS.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private readonly MenuViewModel _viewModel;

        public MenuPage()
        {
            _viewModel = AppFactory.GetInstance<MenuViewModel>();
            InitializeComponent();

            ListViewMenu.SelectedItem = _viewModel.MenuItems[0];
            ListViewMenu.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = ((HomeMenuItem)e.SelectedItem).Id;
                _viewModel.NavigateToCommand.Execute(id);
            };

            BindingContext = _viewModel;
        }
    }
}