using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Metro_Events.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDpu1oTr-MtwRqvacUlH4bq-6n-4gv3Nb0";
        public LoginPage()
        {
            InitializeComponent();
            Type assembly = typeof(LoginPage);
            logoName.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_metro.png", assembly);
            logoIcon.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_icon.png", assembly);
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        private async void Login_button_Clicked(object sender, EventArgs e)
        {
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(login_email.Text, login_password.Text);
                FirebaseAuthLink content = await auth.GetFreshAuthAsync();
                string serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontent);
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                //Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            
        }
    }
}