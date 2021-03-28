using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using smss.Models;
using SQLite;

using Xamarin.Forms;

namespace smss.Views
{
    public class GetAllStudent : ContentPage
    {
        private ListView listView;
        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");
        public GetAllStudent()
        {
            this.Title = "Student List";
            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();


            listView = new ListView();
            listView.ItemsSource = db.Table<Student_list>().OrderBy(x => x.Student_name).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;
        }
    }
}