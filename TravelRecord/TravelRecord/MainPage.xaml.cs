using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            IconImage.Source = ImageSource.FromResource("TravelRecord.Assets.Images.plane.png", assembly);
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {
            var userName = Username.Text;
            var password = Password.Text;

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Username or password incorrect", "Ok");
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        private void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}
