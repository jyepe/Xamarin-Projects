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
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var con = new SQLiteConnection(App.databaseLocation);
            con.CreateTable<Post>();
            var posts = con.Table<Post>().ToList();
            con.Close();
            PostListView.ItemsSource = posts;
        }
    }
}