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
    public class EditStudent : ContentPage
    {

        private ListView listView;
        private Entry _id;
        private Entry _name;
        private Entry _course;
        private Entry _department;
        private Entry _status;
        private Button _button;

        Student_list _Student = new Student_list();

        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db");
        public EditStudent()
        {
            this.Title = "Edit Student information";

            var db = new SQLiteConnection(_dbpath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Student_list>().OrderBy(x => x.Student_name).ToList();
            listView.ItemSelected += listView_ItemSelected;
            stackLayout.Children.Add(listView);

            _id = new Entry();
            _id.Placeholder = "ID";
            _id.IsVisible = false;
            stackLayout.Children.Add(_id);

            _name = new Entry();
            _name.Keyboard = Keyboard.Text;
            _name.Placeholder = "Student Name";
            stackLayout.Children.Add(_name);

            _course = new Entry();
            _course.Keyboard = Keyboard.Text;
            _course.Placeholder = "Student Course";
            stackLayout.Children.Add(_course);

            _department = new Entry();
            _department.Keyboard = Keyboard.Text;
            _department.Placeholder = "Student Department";
            stackLayout.Children.Add(_department);

            _status = new Entry();
            _status.Keyboard = Keyboard.Text;
            _status.Placeholder = "Student Status";
            stackLayout.Children.Add(_status);

            Button button = new Button();
            button.Text = "Update";
            button.Clicked += button_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            Student_list student_list = new Student_list()
            {

                Student_id = Convert.ToInt32(_id.Text),
                Student_name = _name.Text,
                Student_course = _course.Text,
                Student_department = _department.Text,
                Student_status = _status.Text
            };
            db.Update(student_list);
            await Navigation.PopAsync();
        }
        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _Student = (Student_list)e.SelectedItem;
            _id.Text = _Student.Student_id.ToString();
            _name.Text = _Student.Student_name;
            _course.Text = _Student.Student_course;
            _department.Text = _Student.Student_department;
            _status.Text = _Student.Student_status;
        }
    }
}