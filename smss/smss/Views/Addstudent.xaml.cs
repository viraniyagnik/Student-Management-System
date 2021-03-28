using smss.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace smss.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Addstudent : ContentPage
    {
        private Entry name;
        private Entry course;
        private Entry department;
        private Entry status;
        private Button savebutton;

        string _dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"myDB.db");
        public Addstudent()
        {
            InitializeComponent();
            this.Title = "Add Student";
            StackLayout stackLayout = new StackLayout();

            name = new Entry();
            name.Keyboard = Keyboard.Text;
            name.Placeholder = "Student name";
            stackLayout.Children.Add(name);

            course = new Entry();
            course.Keyboard = Keyboard.Text;
            course.Placeholder = "Student course";
            stackLayout.Children.Add(course);

            department = new Entry();
            department.Keyboard = Keyboard.Text;
            department.Placeholder = "Student department";
            stackLayout.Children.Add(department);

            status = new Entry();
            status.Keyboard = Keyboard.Text;
            status.Placeholder = "Student status";
            stackLayout.Children.Add(status);

            savebutton = new Button();
            savebutton.Text = "Add";
            savebutton.Clicked += savebutton_clicked;
            stackLayout.Children.Add(savebutton);

            Content = stackLayout;
        }

        private async void savebutton_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbpath);
            db.CreateTable<Student_list>();

            var maxPk = db.Table<Student_list>().OrderByDescending(s => s.Student_id).FirstOrDefault();

            Student_list student_list = new Student_list()
            {
                Student_id = (maxPk == null ? 1 : maxPk.Student_id + 1),
                Student_name = name.Text,
                Student_course = course.Text,
                Student_department = department.Text,
                Student_status = status.Text
            };

            db.Insert(student_list);
            await DisplayAlert(null, student_list.Student_name + " Added", "OK");

            await Navigation.PopAsync();
        }
    }
}