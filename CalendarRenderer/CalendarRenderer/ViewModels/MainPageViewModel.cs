using CalendarRenderer.Models;
using CalendarRenderer.Models.Enums;
using CalendarRenderer.Models.Events;
using CalendarRenderer.Models.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Behaviors;

namespace CalendarRenderer.ViewModels
{
    /// <summary>
    /// View model of the main page
    /// </summary>
    public class MainPageViewModel : ContentPage, INotifyPropertyChanged
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Properties
        public string DateLabel
        {

            get
            {
                return this.GetDateLabel();
            }
        }

        private DateTime _calendarDateTime;
        public DateTime CalendarDateTime
        {

            get
            {
                return _calendarDateTime;
            }
            set
            {
                _calendarDateTime = value;
                this.OnPropertyChanged(nameof(CalendarDateTime));
            }
        }

        private CalendarGridViewModel _calendarGridViewContextModel;
        public CalendarGridViewModel CalendarGridViewModel
        {

            get
            {
                return _calendarGridViewContextModel;
            }
            set
            {
                _calendarGridViewContextModel = value;
                this.OnPropertyChanged(nameof(CalendarGridViewModel));
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
                this.OnPropertyChanged(nameof(CellBackgroundColor));
            }
        }

        private Color _textColor;
        public Color TextColor
        {

            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                this.OnPropertyChanged(nameof(TextColor));
            }
        }

        private Color _cellColor;
        public Color CellColor
        {

            get
            {
                return _cellColor;
            }
            set
            {
                _cellColor = value;
                this.OnPropertyChanged(nameof(CellColor));
            }
        }

        #region Commands
        public ICommand PreviousButtonCommand { get; protected set; }
        public ICommand CurrentButtonCommand { get; protected set; }
        public ICommand NextButtonCommand { get; protected set; }
        #endregion

        #endregion

        public MainPageViewModel()
        {
            
        }

        public RelayGesture DumpParam { get; set; }

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            //g is a GestureResult and x is the GestureParameter
            DumpParam = new RelayGesture((g, x) => Debug.WriteLine("DUMPING {0} from a {1}[{2}]", x, g.GestureType, g.Direction));


            this.PreviousButtonCommand = new Command(this.PreviousButtonClicked);
            this.CurrentButtonCommand = new Command(this.CurrentDateButtonClicked);
            this.NextButtonCommand = new Command(this.NextButtonClicked);

            _eventAggregator = eventAggregator;
            this.CalendarDateTime = DateTime.Now;
            this.ActualizeDisplayedDate();

            this.CalendarGridViewModel = new CalendarGridViewModel(_eventAggregator);
            this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);

            _eventAggregator.GetEvent<MonthClickedEvent>().Subscribe(MonthClicked);
            _eventAggregator.GetEvent<DependecyPropertyChangedEvent>().Subscribe(DependecyPropertyChanged);
        }

        #region Methods

        /// <summary>
        /// Refresh displayed date
        /// </summary>
        private void ActualizeDisplayedDate()
        {
            this.OnPropertyChanged(nameof(this.DateLabel));
        }

        /// <summary>
        /// Get the displayed date information in function of the grid mode
        /// </summary>
        /// <returns></returns>
        private string GetDateLabel()
        {
            /// At the beginning of the app, the context may be null
            if (this.CalendarGridViewModel == null)
                return string.Empty;

            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    return this.CalendarDateTime.ToString(DateTimeHelper.monthFormat) + " " + this.CalendarDateTime.ToString(DateTimeHelper.yearFormat);

                case DisplayMode.YearMode:
                    return this.CalendarDateTime.ToString(DateTimeHelper.yearFormat);

                default:
                    throw new NotSupportedException();

            }
        }

        /// <summary>
        /// Method executed wen the button previous is clicked, execute instructions in function of the displayed grid mode
        /// </summary>
        private void PreviousButtonClicked()
        {
            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    /// Decrement month
                    this.CalendarDateTime = this.CalendarDateTime.AddMonths(-1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeMonth(this.CalendarDateTime);

                    break;
                case DisplayMode.YearMode:
                    /// Decrement year
                    this.CalendarDateTime = this.CalendarDateTime.AddYears(-1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);
                    break;
                default:
                    break;
            }

            /// Refresh displayed date
            this.ActualizeDisplayedDate();

        }

        /// <summary>
        /// Method executed when the user clicked on the button where the date is displayed
        /// Load the previous grid mode and load data
        /// </summary>
        private void CurrentDateButtonClicked()
        {
            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    /// Refresh displayed date
                    this.ActualizeDisplayedDate();
                    this.CalendarGridViewModel.DisplayMode = DisplayMode.YearMode;

                    /// Load informations of grid with the selected month
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);

                    break;
                case DisplayMode.YearMode:
                    /// Do nothing, Year mode is the last mode 
                    break;
                default:
                    break;
            }

            /// Refresh displayed date
            this.ActualizeDisplayedDate();
        }

        /// <summary>
        /// Method executed wen the button next is clicked, execute instructions in function of the displayed grid mode
        /// </summary>
        private void NextButtonClicked()
        {
            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    /// Increment month
                    this.CalendarDateTime = this.CalendarDateTime.AddMonths(1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeMonth(this.CalendarDateTime);

                    break;
                case DisplayMode.YearMode:
                    /// Increment year
                    this.CalendarDateTime = this.CalendarDateTime.AddYears(1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);

                    break;
                default:
                    break;
            }

            /// Refresh displayed date
            this.ActualizeDisplayedDate();
        }

        /// <summary>
        /// Method executed when a click on a month is realized
        /// Load the data for the selected month
        /// </summary>
        /// <param name="obj"></param>
        private void MonthClicked(MonthClickedEventArgs obj)
        {
            /// Pass into month mode
            this.CalendarGridViewModel.DisplayMode = DisplayMode.MonthMode;

            /// Load informations of grid with the selected month
            var newDateTime = DateTimeHelper.GetDateSwitchingToMonthMode(obj.ClickedMonth.Year, obj.ClickedMonth.NumberMonth, DateTime.Now.Day);
            this.CalendarGridViewModel.LoadGridModeMonth(newDateTime);

            /// Refresh displayed date
            this.CalendarDateTime = newDateTime;
            this.ActualizeDisplayedDate();
        }

        /// <summary>
        /// Method executed when a dependency property changed
        /// Use because the constructor of the main page is executed before the propety changed method of all dependency properties
        /// Allows to reload the grid with the new value of the dependecy properties
        /// </summary>
        /// <param name="obj"></param>
        private void DependecyPropertyChanged(DependecyPropertyChangedEventArgs obj)
        {
            var dependecyProperties = obj.DependecyProps;

            this.CellBackgroundColor = dependecyProperties.CellBackgroundColor;
            this.TextColor = dependecyProperties.TextColor;
            this.CellColor = dependecyProperties.CellColor;
            
        }

        #endregion
    }
}
