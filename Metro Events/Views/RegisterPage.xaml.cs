using Firebase.Auth;
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
    public partial class RegisterPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDpu1oTr-MtwRqvacUlH4bq-6n-4gv3Nb0";
        public RegisterPage()
        {
            InitializeComponent();
            var assembly = typeof(LoginPage);
            logoName.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_metro.png", assembly);
            logoIcon.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_icon.png", assembly);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Register_button_Clicked(object sender, EventArgs e)
        {
            try
            {
                FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                FirebaseAuthLink auth = await authProvider.CreateUserWithEmailAndPasswordAsync(register_email.Text, register_password.Text, register_username.Text);
                
                string gettoken = auth.FirebaseToken;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
            
        }
    }
}