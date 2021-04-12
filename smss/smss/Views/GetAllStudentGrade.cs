using smss.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace smss.Views
{
    public class GetAllStudentGrade : ContentPage
    {
        private ListView listView;
        string _dbpath1 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB1.db");
        public GetAllStudentGrade()
        {
            this.Title = "Student Grade Report";
            var db1 = new SQLiteConnection(_dbpath1);

            StackLayout stackLayout = new StackLayout();


            listView = new ListView();
            listView.ItemsSource = db1.Table<Student_grade>().OrderBy(x => x.Student_name).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;
        }
    }
}