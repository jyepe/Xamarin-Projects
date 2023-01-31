using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    public partial class App : Application
    {
        public static string databaseLocation = String.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            App.databaseLocation = databaseLocation;
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
