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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            var assembly = typeof(WelcomePage);
            logoName.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_metro.png", assembly);
            logoIconNs.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_icon_ns.png", assembly);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushModalAsync(new RegisterPage());
        }

        private void Log_In_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushModalAsync(new LoginPage());
        }
    }
}