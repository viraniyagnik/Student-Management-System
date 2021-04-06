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
    public partial class TimeTable : ContentPage
    {
        public TimeTable()
        {
            InitializeComponent();

            BindingContext = new TimeTableViewModel();

            var Table = new Image()
            {
                Source = "time_table.png"
            };


            Content = new StackLayout() { Padding = 05, Children = { Table } };
        }
    }
}