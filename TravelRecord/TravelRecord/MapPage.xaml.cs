using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Xamarin.Forms.Maps.Position;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private IGeolocator _locator = CrossGeolocator.Current;

        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _locator.StopListeningAsync();
        }

        private async void GetLocation()
        {
            var status = await CheckPermission();

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();
               
                _locator.PositionChanged += LocatorOnPositionChanged;
                await _locator.StartListeningAsync(new TimeSpan(0, 1, 0), 100);
                Map.IsShowingUser = true;
                CenterMap(location.Latitude, location.Longitude);
            }
        }

        private void LocatorOnPositionChanged(object sender, PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double lat, double @long)
        {
            var center = new Position(lat, @long);
            var mapSpan = new MapSpan(center, 1, 1);
            Map.MoveToRegion(mapSpan);
        }

        private async Task<PermissionStatus> CheckPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
            {
                return status;
            }



            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }
    }
}