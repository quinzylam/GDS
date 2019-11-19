using Xamarin.Essentials;
using Xamarin.Forms;
using GDS.Mobile.Views;

namespace GDS.Mobile
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? Constants.API_URL_DROID : Constants.API_URL;

        public static bool UseMockDataStore = true;

        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = IsUserLoggedIn ? new NavigationPage(new MainPage()) : new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}