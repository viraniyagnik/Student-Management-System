using smss.Models;
using smss.ViewModels;
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
    public partial class Grade_Report : ContentPage
    {
        

        public Grade_Report()
        {
            InitializeComponent();

            BindingContext = new GradeReportViewModel();

            StackLayout stackLayout = new StackLayout();




            this.Title = "Select Option";

            Button button = new Button();
            button.Text = "Add Student Grade Report";
            button.Clicked += Button_Clicked;


            Button button1 = new Button();
            button1.Text = "Get Student Grade Report";
            button1.Clicked += Button_Get_Clicked;

            Button button2 = new Button();
            button2.Text = "Edit Student Grade";
            button2.Clicked += Button_Edit_Clicked;

            Button button3 = new Button();
            button3.Text = "Delete Student Grade Report";
            button3.Clicked += Button_Delete_Clicked;

            Content = new StackLayout() { Padding = 10, Children = { button, button1, button2, button3 }, };




        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddstudentGrade());
        }
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllStudentGrade());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditStudentGrade());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteStudentGrade());
        }


    }

       



    
}