using CalendarRenderer.Models;
using CalendarRenderer.Models.Events;
using CalendarSample.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private MainPage _mainPage;
        private DayDetailPage _dayDetailPage;
        private ObservableCollection<DayActivity> _activies;

        public ObservableCollection<DayActivity> Activities
        {
            get { return _activies; }
            set
            {
                if (_activies != value)
                {
                    _activies = value;
                }
                this.OnPropertyChanged(nameof(Activities));
            }
        }

        public MainPageViewModel(MainPage mainPage)
        {
            _mainPage = mainPage;
            _mainPage.Appearing += MainPageAppearing;
        }

        /// <summary>
        /// Method executed when user click on a specific day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnDayClicked(object sender, EventArgs e)
        {
            /// Open and display the DayDetailPage
            var dayClickedEventArgs = (DayClickedEventArgs)e;
            _dayDetailPage = new DayDetailPage(dayClickedEventArgs.ClickedDay);
            Application.Current.MainPage.Navigation.PushAsync(_dayDetailPage);
            NavigationPage.SetHasBackButton(_dayDetailPage, true);
        }

        /// <summary>
        /// Method executed when the page appears
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPageAppearing(object sender, EventArgs e)
        {
            if (_dayDetailPage != null)
            {
                var dayDetailPageVM = (DayDetailPageViewModel)_dayDetailPage.BindingContext;

                this.Activities = dayDetailPageVM.Activities;
            }
        }
    }
}
