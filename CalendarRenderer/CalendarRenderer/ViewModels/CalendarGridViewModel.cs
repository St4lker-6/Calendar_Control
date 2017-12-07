using CalendarRenderer.Models;
using CalendarRenderer.Models.Enums;
using CalendarRenderer.Models.Events;
using CalendarRenderer.Models.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.ViewModels
{
    /// <summary>
    /// View model of the calendar grid view
    /// </summary>
    public class CalendarGridViewModel : ViewModelBase
    {
        #region Fields
        private IEventAggregator _eventAggregator;
        #endregion

        #region Properties
        private ObservableCollection<Year> _years;
        public ObservableCollection<Year> Years
        {
            get
            {
                return _years;
            }
            set
            {
                _years = value;
                this.NotifyPropertyChanged(nameof(Years));
            }
        }

        private ObservableCollection<Week> _weeks;
        public ObservableCollection<Week> Weeks
        {
            get
            {
                return _weeks;
            }
            set
            {
                _weeks = value;
                this.NotifyPropertyChanged(nameof(Weeks));
            }
        }

        private Month _currentMonth;
        public Month CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                this.NotifyPropertyChanged(nameof(CurrentMonth));
            }
        }

        private DisplayMode _displayMode;
        public DisplayMode DisplayMode
        {

            get
            {
                return _displayMode;
            }
            set
            {
                _displayMode = value;
                this.NotifyPropertyChanged(nameof(DisplayMode));
            }
        }

        #endregion


        public CalendarGridViewModel(IEventAggregator eventAggregator)
        {
            /// Set the month mode by default
            this.DisplayMode = DisplayMode.YearMode;
            
            _eventAggregator = eventAggregator;
        }

        #region Methods

        /// <summary>
        /// Load data for the selected month
        /// </summary>
        /// <param name="newDate"></param>
        public void LoadGridModeMonth(DateTime newDate)
        {
            this.CurrentMonth = DateTimeHelper.GetDateInformationsMonthMode(newDate);
        }

        /// <summary>
        /// Load data for the selected year
        /// </summary>
        /// <param name="newDate"></param>
        public void LoadGridModeYear(DateTime newDate)
        {
            this.Years = DateTimeHelper.GetDateInformationsYearMode(newDate);
        }

        #endregion
    }
}
