using GDS.Core.Services;
using GDS.Mobile.Factories;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GDS.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri(Constants.WEBSITE_URL)));
        }

        public ICommand OpenWebCommand { get; }
    }
}