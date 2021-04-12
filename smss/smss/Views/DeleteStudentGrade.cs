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
    public class DeleteStudentGrade : ContentPage
    {
        private ListView listView;
        private Button button;

        Student_grade student_grade = new Student_grade();

        string _dbpath1 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB1.db");
        public DeleteStudentGrade()
        {
            this.Title = "Delete Student Report";

            var db1 = new SQLiteConnection(_dbpath1);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db1.Table<Student_grade>().OrderBy(x => x.Student_name).ToList();
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
            student_grade = (Student_grade)e.SelectedItem;

        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db1 = new SQLiteConnection(_dbpath1);


            db1.Table<Student_grade>().Delete(x => x.Student_id == student_grade.Student_id);
            await Navigation.PopAsync();
        }
    }
}