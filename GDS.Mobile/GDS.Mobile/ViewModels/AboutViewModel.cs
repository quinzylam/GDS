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

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://wirelessministeringevents.co.za")));
        }

        public ICommand OpenWebCommand { get; }
    }
}