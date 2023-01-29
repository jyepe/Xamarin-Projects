using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
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