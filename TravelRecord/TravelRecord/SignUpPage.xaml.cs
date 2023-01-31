using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    Name = Name.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    Username = UserName.Text
                };

                var con = new SQLiteConnection(App.databaseLocation);
                con.CreateTable<User>();
                var rowsAdded = con.Insert(user);
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
            catch (Exception exception)
            {
                DisplayAlert("Failure", "Row not added", "ok");
            }
        }
    }
}