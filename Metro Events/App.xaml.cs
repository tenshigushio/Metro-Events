using Xamarin.Essentials;
using Xamarin.Forms;
using Metro_Events.Views;

namespace Metro_Events
{
    public partial class App : Application
    {
        
        public App(string fullPath)
        {
            InitializeComponent();

            MainPage = !string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", ""))
                ? new NavigationPage(new HomePage())
                : new NavigationPage(new LandingPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
