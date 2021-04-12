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
    public class AddstudentGrade : ContentPage
    {
        private Entry name;
        private Entry subject1;
        private Entry subject2;
        private Entry subject3;
        private Button savebutton;

        string _dbpath1 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB1.db");
        public AddstudentGrade()
        {
 
            
            this.Title = "Add Subject Marks";
            StackLayout stackLayout = new StackLayout();

            name = new Entry();
            name.Keyboard = Keyboard.Text;
            name.Placeholder = "Student name";
            stackLayout.Children.Add(name);

            subject1 = new Entry();
            subject1.Keyboard = Keyboard.Text;
            subject1.Placeholder = "OOP Marks";
            stackLayout.Children.Add(subject1);

            subject2 = new Entry();
            subject2.Keyboard = Keyboard.Text;
            subject2.Placeholder = "Maths Marks";
            stackLayout.Children.Add(subject2);

            subject3 = new Entry();
            subject3.Keyboard = Keyboard.Text;
            subject3.Placeholder = "Java Marks";
            stackLayout.Children.Add(subject3);

            savebutton = new Button();
            savebutton.Text = "Add";
            savebutton.Clicked += savebutton_clicked;
            stackLayout.Children.Add(savebutton);

            Content = stackLayout;
        }

        private async void savebutton_clicked(object sender, EventArgs e)
        {
            var db1 = new SQLiteConnection(_dbpath1);
            db1.CreateTable<Student_grade>();

            var maxPk = db1.Table<Student_grade>().OrderByDescending(s => s.Student_id).FirstOrDefault();

            Student_grade student_grade = new Student_grade()
            {
                Student_id = (maxPk == null ? 1 : maxPk.Student_id + 1),
                Student_name = name.Text,
                Student_subject1 = subject1.Text,
                Student_subject2 = subject2.Text,
                Student_subject3 = subject3.Text
            };

            db1.Insert(student_grade);
            await DisplayAlert(null, student_grade.Student_name + " Marks Added ", "OK");

            await Navigation.PopAsync();
        }
    }
}