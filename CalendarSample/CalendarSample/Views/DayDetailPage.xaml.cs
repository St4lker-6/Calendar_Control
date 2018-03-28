using CalendarSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayDetailPage : ContentPage
    {
        public DayDetailPage(CalendarRenderer.Models.Day clickedDay)
        {
            InitializeComponent();
            this.Title = string.Format("{0} {1} {2} {3}", clickedDay.CurrentDateTime.ToString("ddd"), clickedDay.CurrentDateTime.Day, clickedDay.CurrentDateTime.ToString("MMMM"), clickedDay.Year);
            this.BindingContext = new DayDetailPageViewModel(clickedDay);

        }
    }
}