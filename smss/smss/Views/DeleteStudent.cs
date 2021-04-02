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
    public class DeleteStudent : ContentPage
    {

        private ListView listView;
        private Button button;

        Student_list student_list = new Student_list();

        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");
        public DeleteStudent()
        {

            this.Title = "Delete Student";

            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Student_list>().OrderBy(x => x.Student_name).ToList();
            listView.ItemSelected += listView_ItemSelected;
            stackLayout.Children.Add(listView);

            Button button = new Button();
            button.Text = "Delete";
            button.Clicked += button_Clicked;
            stackLayout.Children.Add(button);
            Content = stackLayout;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            student_list = (Student_list)e.SelectedItem;
            
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);


            db.Table<Student_list>().Delete(x => x.Student_id == student_list.Student_id);
            await Navigation.PopAsync();
        }
    }
}