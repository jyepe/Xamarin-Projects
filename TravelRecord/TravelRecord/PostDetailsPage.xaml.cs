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
    public partial class PostDetailsPage : ContentPage
    {
        private readonly Post _selectedPost;

        public PostDetailsPage(Post post)
        {
            InitializeComponent();
            _selectedPost = post;
            ExperienceEntry.Text = _selectedPost.Experience;
        }

        private void EditButton_OnClicked(object sender, EventArgs e)
        {
            _selectedPost.Experience = ExperienceEntry.Text;
            using (var con = new SQLiteConnection(App.databaseLocation))
            {
                con.CreateTable<Post>();
                con.Update(_selectedPost);
            }
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(App.databaseLocation))
            {
                con.CreateTable<Post>();
                con.Delete(_selectedPost);
            }
        }
    }
}