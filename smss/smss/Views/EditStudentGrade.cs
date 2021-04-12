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
    public class EditStudentGrade : ContentPage
    {
        private ListView listView;
        private Entry _id;
        private Entry _name;
        private Entry _subject1;
        private Entry _subject2;
        private Entry _subject3;
        private Button _button;

        Student_grade _Student = new Student_grade();

        string _dbpath1 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB1.db");
        public EditStudentGrade()
        {
            this.Title = "Edit Student information";

            var db1 = new SQLiteConnection(_dbpath1);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db1.Table<Student_grade>().OrderBy(x => x.Student_name).ToList();
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

            _subject1 = new Entry();
            _subject1.Keyboard = Keyboard.Text;
            _subject1.Placeholder = "OOP Marks";
            stackLayout.Children.Add(_subject1);

            _subject2 = new Entry();
            _subject2.Keyboard = Keyboard.Text;
            _subject2.Placeholder = "Maths Marks";
            stackLayout.Children.Add(_subject2);

            _subject3 = new Entry();
            _subject3.Keyboard = Keyboard.Text;
            _subject3.Placeholder = "Java Marks";
            stackLayout.Children.Add(_subject3);

            Button button = new Button();
            button.Text = "Update";
            button.Clicked += button_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db1 = new SQLiteConnection(_dbpath1);
            Student_grade student_grade = new Student_grade()
            {

                Student_id = Convert.ToInt32(_id.Text),
                Student_name = _name.Text,
                Student_subject1 = _subject1.Text,
                Student_subject2 = _subject2.Text,
                Student_subject3 = _subject3.Text
            };
            db1.Update(student_grade);
            await Navigation.PopAsync();
        }
        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _Student = (Student_grade)e.SelectedItem;
            _id.Text = _Student.Student_id.ToString();
            _name.Text = _Student.Student_name;
            _subject1.Text = _Student.Student_subject1;
            _subject2.Text = _Student.Student_subject2;
            _subject3.Text = _Student.Student_subject3;
        }
    }
}