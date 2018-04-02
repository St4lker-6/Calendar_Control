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
using Xamarin.Forms;

namespace CalendarRenderer.ViewModels
{
    /// <summary>
    /// View model of the calendar grid view
    /// </summary>
    public class CalendarGridViewModel : ViewModelBase
    {
        #region Fields
        private IEventAggregator _eventAggregator;
        private DateTime _currentBrowsedDate;
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

        private Color _cellBackgroundColor;
        public Color CellBackgroundColor
        {

            get
            {
                return _cellBackgroundColor;
            }
            set
            {
                _cellBackgroundColor = value;
                this.NotifyPropertyChanged(nameof(CellBackgroundColor));
            }
        }
        private DependencyProperties _dependecyProperties;

        #endregion

        public CalendarGridViewModel()
        {

        }

        public CalendarGridViewModel(IEventAggregator eventAggregator)
        {
            /// Set the month mode by default
            this.DisplayMode = DisplayMode.YearMode;
            
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<DependecyPropertyChangedEvent>().Subscribe(DependecyPropertyChanged);

            this.Years = new ObservableCollection<Year>();
        }

        #region Methods

        /// <summary>
        /// Load data for the selected month
        /// </summary>
        /// <param name="newDate"></param>
        public void LoadGridModeMonth(DateTime newDate)
        {
            _currentBrowsedDate = newDate;
            this.CurrentMonth = DateTimeHelper.GetDateInformationsMonthMode(newDate, _dependecyProperties);
        }

        /// <summary>
        /// Load data for the selected year
        /// </summary>
        /// <param name="newDate"></param>
        public void LoadGridModeYear(DateTime newDate)
        {
            _currentBrowsedDate = newDate;
            this.Years = DateTimeHelper.GetDateInformationsYearMode(newDate, _dependecyProperties);
        }

        /// <summary>
        /// Method executed when a dependency property changed
        /// Use because the constructor of the main page is executed before the propety changed method of all dependency properties
        /// Allows to reload the grid with the new value of the dependecy properties
        /// </summary>
        /// <param name="obj"></param>
        private void DependecyPropertyChanged(DependecyPropertyChangedEventArgs obj)
        {
            _dependecyProperties = obj.DependecyProps;

            this.CellBackgroundColor = _dependecyProperties.CellBackgroundColor;

            switch (this.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    this.LoadGridModeMonth(_currentBrowsedDate);
                    break;

                case DisplayMode.YearMode:
                    this.LoadGridModeYear(_currentBrowsedDate);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        #endregion
    }
}
