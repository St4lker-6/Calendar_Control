using CalendarRenderer.Models.Enums;
using CalendarRenderer.Models.Services;
using CalendarRenderer.ViewModels;
using CalendarRenderer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(ApplicationService.Instance.EventAggregator);
        }
    }
}
