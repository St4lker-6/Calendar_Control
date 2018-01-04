using CalendarRenderer.Models.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
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

        public ICommand DayClickCommand { get; private set; }


        public Day(IEventAggregator eventAggregator, DependencyProperties dependencyProperties, int numberDay, string nameDay, int numberMonth, int year, bool valid, bool isCurrentDay = false)
        {
            _eventAggregator = eventAggregator;
            this.NumberDay = numberDay;
            this.NameDay = nameDay;
            this.NumberMonth = numberMonth;
            this.Year = year;
            this.Valid = valid;
            this.IsCurrentDay = isCurrentDay;

            if (dependencyProperties != null)
            {
                this.CurrentDayColor = dependencyProperties.CurrentDayColor;
                this.TextColor = dependencyProperties.TextColor;
                this.CellColor = dependencyProperties.CellColor;
            }

            DayClickCommand = new Command(DayClicked);
        }

        private void DayClicked()
        {
            _eventAggregator.GetEvent<DayClickedEvent>().Publish(new DayClickedEventArgs(this));
        }
    }
}
