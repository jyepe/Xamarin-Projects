using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using SQLite;
using TravelRecord.Logic;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = VenueLogic.GetVenues(position.Latitude, position.Longitude);
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            var post = new Post
            {
                Experience = EntryTextBox.Text,
            };

            var con = new SQLiteConnection(App.databaseLocation);
            con.CreateTable<Post>();
            var rowsAdded = con.Insert(post);
            con.Close();

            if (rowsAdded > 0)
            {
                DisplayAlert("Success", "Row added", "ok");
            }
            else
            {
                DisplayAlert("Failure", "Row not added", "ok");
            }
        }
    }
}