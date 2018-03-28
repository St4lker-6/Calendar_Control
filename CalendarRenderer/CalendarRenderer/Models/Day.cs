using CalendarRenderer.Models.Events;
using CalendarRenderer.Models.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalendarRenderer.Models
{
    public class Day
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;

        #endregion

        public DateTime CurrentDateTime { get; private set; }
        public int NumberDay { get; private set; }
        public string NameDay { get; private set; }
        public int NumberMonth { get; private set; }
        public int Year { get; private set; }
        public bool IsCurrentDay { get; private set; }

        /// <summary>
        /// Invalid if the day is a day of an another month
        /// </summary>
        public bool Valid { get; private set; }

        /// Need to be in public to be able to bind on
        public Color CurrentDayColor { get; private set; }
        public Color TextColor { get; private set; }
        public Color CellColor { get; private set; }
        public ObservableCollection<DayActivity> Activities { get; private set; }

        public ICommand DayClickCommand { get; private set; }


        public Day(IEventAggregator eventAggregator, DependencyProperties dependencyProperties, DateTime dateTime, bool valid, bool isCurrentDay = false)
        {
            _eventAggregator = eventAggregator;

            this.CurrentDateTime = dateTime;
            this.NumberDay = dateTime.Day;
            this.NameDay = dateTime.ToString(DateTimeHelper.dayFormat);
            this.NumberMonth = dateTime.Month;
            this.Year = dateTime.Year;
            this.Valid = valid;
            this.IsCurrentDay = isCurrentDay;

            if (dependencyProperties != null)
            {
                this.CurrentDayColor = dependencyProperties.CurrentDayColor;
                this.TextColor = dependencyProperties.TextColor;
                this.CellColor = dependencyProperties.CellColor;


                //this.Activities = this.FilterActivities(dateTime, dependencyProperties.Activities);
                //this.Activities = new ObservableCollection<DayActivity>();
                //this.Activities.Add(new DayActivity(DateTime.Now, "test", Color.Red));
                //this.Activities.Add(new DayActivity(DateTime.Now, "test", Color.Red));
                //this.Activities.Add(new DayActivity(DateTime.Now, "test", Color.Red));
                //this.Activities.Add(new DayActivity(DateTime.Now, "test", Color.Red));
            }

            DayClickCommand = new Command(DayClicked);
        }

        private void DayClicked()
        {
            _eventAggregator.GetEvent<DayClickedEvent>().Publish(new DayClickedEventArgs(this));
        }

        /// <summary>
        /// Allows to take only the activities of the current day
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        private ObservableCollection<DayActivity> FilterActivities(DateTime browsingDateTime, ObservableCollection<DayActivity> activities)
        {
            if (activities == null)
                return null;

            var currentDayAcitivities = new ObservableCollection<DayActivity>();

            foreach (var activity in activities)
            {
                if (activity.CurrentDateTime.Date == browsingDateTime.Date)
                {
                    currentDayAcitivities.Add(activity);
                }
            }

            return currentDayAcitivities;


        }
    }
}
