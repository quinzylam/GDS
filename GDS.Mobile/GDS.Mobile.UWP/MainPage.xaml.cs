using GDS.Mobile.Factories;
using GDS.Mobile.Services;
using GDS.Mobile.UWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GDS.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            RegisterTypes();
            LoadApplication(new GDS.Mobile.App());
        }

        private void RegisterTypes()
        {
            AppFactory.RegisterType<IExitService, ExitService>();
            AppFactory.RegisterService();
        }
    }
}