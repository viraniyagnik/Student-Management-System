using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using smss.ViewModels;

namespace smss.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Student_List : ContentPage
    {
        public Student_List()
        {
            InitializeComponent();
            BindingContext = new Student_ListVeiwModel();

            StackLayout stackLayout = new StackLayout();

          
           

            this.Title = "Select Option";

            Button button = new Button();
            button.Text = "Add Student";
            button.Clicked += Button_Clicked;
            

            Button button1 = new Button();
            button1.Text = "Get Student List";
            button1.Clicked += Button_Get_Clicked;

            Button button2 = new Button();
            button2.Text = "Edit";
            button2.Clicked += Button_Edit_Clicked;

            Button button3 = new Button();
            button3.Text = "Delete";
            button3.Clicked += Button_Delete_Clicked;

            Content = new StackLayout() { Padding = 05, Children = { button, button1, button2, button3 }, };




        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addstudent());
        }
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllStudent());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditStudent());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteStudent());
        }

    }
}