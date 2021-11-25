using Firebase.Auth;
using Metro_Events.Models;
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
    public partial class HomePage : TabbedPage
    {
        public string WebAPIkey = "AIzaSyDpu1oTr-MtwRqvacUlH4bq-6n-4gv3Nb0";
        public IList<Event> Events { get; private set; }
        public HomePage()
        {
            
            InitializeComponent();
            Type assembly = typeof(HomePage);
            profilePic.Source = ImageSource.FromResource("Metro_Events.Assets.images.logo.metroevents_icon.png", assembly);
            Home.IconImageSource = ImageSource.FromResource("Metro_Events.Assets.images.icons.home.png", assembly);
            Favorites.IconImageSource = ImageSource.FromResource("Metro_Events.Assets.images.icons.bookmark.png", assembly);
            Tickets.IconImageSource = ImageSource.FromResource("Metro_Events.Assets.images.icons.invoice.png", assembly);
            Notification.IconImageSource = ImageSource.FromResource("Metro_Events.Assets.images.icons.notification.png", assembly);
            Profile.IconImageSource = ImageSource.FromResource("Metro_Events.Assets.images.icons.user.png", assembly);

            GetProfileInformationAndRefreshTokenAsync();
            NavigationPage.SetHasNavigationBar(this, false);

            Events = new List<Event>
            {
                new Event
                {
                    EventId = "001",
                    EventName = "Metro Events Launching",
                    Category = "Technology",
                    Event_date = "Nov. 25, 2021",
                    ImageUrl = "https://images.unsplash.com/photo-1492684223066-81342ee5ff30?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                new Event
                {
                    EventId = "002",
                    EventName = "Colour Exhibit",
                    Category = "Exhibit",
                    Event_date = "Dec. 1, 2022",
                    ImageUrl = "https://images.unsplash.com/photo-1496024840928-4c417adf211d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
                },
                new Event
                {
                    EventId = "003",
                    EventName = "Virtual Speaking Masterclass Cebu City",
                    Category = "Class",
                    Event_date = "Nov. 26, 2021",
                    ImageUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F121853949%2F146186060097%2F1%2Foriginal.20201127-181631?w=800&auto=format%2Ccompress&q=75&sharp=10&rect=245%2C0%2C1560%2C780&s=9ae0d347e728fe5445b4469410ab06dc"
                },
                new Event
                {
                    EventId = "004",
                    EventName = "The Antidote: Guided Meditation Class",
                    Category = "Class",
                    Event_date = "Dec. 1, 2021",
                    ImageUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F165273879%2F4115290788%2F1%2Foriginal.20211011-235047?w=800&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C164%2C504%2C252&s=93197e9b2854f8b727680a7e9ab12826"
                },
                new Event
                {
                    EventId = "005",
                    EventName = "Tech Career Fair: Exclusive Tech Hiring Event-New Tickets Available",
                    Category = "Class",
                    Event_date = "Dec. 18, 2021",
                    ImageUrl = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F129219001%2F197361445633%2F1%2Foriginal.20210316-120602?w=800&auto=format%2Ccompress&q=75&sharp=10&rect=173%2C0%2C2160%2C1080&s=dbc4ee6a4d6d2bc4a8ead9ba9d885b3c"
                },
            };

            BindingContext = this;

        }

        private async void GetProfileInformationAndRefreshTokenAsync()
        {
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //saved firebase auth that was saved during login time
                FirebaseAuth savedfirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //refresh token
                FirebaseAuthLink refreshedcontent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                //grab user info
                UserEmail.Text = savedfirebaseauth.User.Email;
                Username.Text = "@" + savedfirebaseauth.User.DisplayName;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("Alert", "Oh no! Not good.", "Exit");
            }
        }

        private void TabbedPage_Focused(object sender, FocusEventArgs e)
        {

        }

        public void SearchBar_textChanged(object sender, TextChangedEventArgs e)
        {
            var searchresults = Events.Where(value => value.EventName.Contains(searchEvent.Text));
            Eventlist.ItemsSource = searchresults;


        }

        private void LogOut_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            Application.Current.MainPage = new NavigationPage(new WelcomePage());
        }


    }
}