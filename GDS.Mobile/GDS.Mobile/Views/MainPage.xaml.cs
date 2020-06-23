using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GDS.Mobile.Models;
using GDS.Mobile.Models.Enums;
using GDS.Mobile.Factories;
using GDS.Mobile.Services;

namespace GDS.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private readonly Dictionary<int, NavigationPage> _menuPages = new Dictionary<int, NavigationPage>();
        public MenuItemType CurrentMenu { get; internal set; }
        public MenuItemType PrevMenu { get; internal set; }

        public MainPage()
        {
            InitializeComponent();

            Master = new MenuPage();

            Detail = new NavigationPage(new ReadPage());

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Read:
                        AddToMenu(id, new ReadPage());
                        break;

                    case (int)MenuItemType.Library:
                        AddToMenu(id, new LibraryPage());
                        break;

                    case (int)MenuItemType.About:
                        AddToMenu(id, new AboutPage());
                        break;
                }
            }

            var newPage = _menuPages[id];

            await NavigateTo(newPage);
        }

        private async Task NavigateTo(NavigationPage newPage)
        {
            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public static void ExitApp()
        {
            var closer = AppFactory.GetInstance<IExitService>();
            closer?.CloseApplication();
        }

        public void AddToMenu(int id, ContentPage page)
        {
            _menuPages.Add(id, new NavigationPage(page));
        }

        public async Task Back()
        {
            Detail = new NavigationPage(new MenuPage());
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);
        }
    }
}