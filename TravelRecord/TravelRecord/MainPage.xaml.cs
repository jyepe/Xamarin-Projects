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
        }

        private void LoginButton_OnClicked(object sender, EventArgs e)
        {
            var userName = Username.Text;
            var password = Password.Text;

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
               
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        private void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
