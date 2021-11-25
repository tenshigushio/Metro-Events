using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Metro_Events.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        
        public LandingPage()
        {
            InitializeComponent();
            var assembly = typeof(LandingPage);
            logoName.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_metro.png", assembly);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SimulatesStartUp();
            
        }

        async Task SimulatesStartUp()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Application.Current.MainPage = new NavigationPage(new WelcomePage());
        }

    }
}