using CalendarRenderer.Models;
using CalendarRenderer.Models.Events;
using CalendarRenderer.ViewModels;
using CalendarSample.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarSample
{
    public partial class MainPage : ContentPage
    {
        private CalendarSample.ViewModels.MainPageViewModel _viewModel;
        private ObservableCollection<DayActivity> _activies;

        public ObservableCollection<DayActivity> Activities
        {
            get { return _activies; }
            set
            {
                if (_activies != value)
                {
                    _activies = value;
                    this.OnPropertyChanged(nameof(Activities));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new CalendarSample.ViewModels.MainPageViewModel(this);
            this.BindingContext = _viewModel;
        }

        /// <summary>
        /// Method executed when user clicked on a specific day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DayClicked(object sender, EventArgs e)
        {
            _viewModel.OnDayClicked(sender, e);
        }
    }
}
