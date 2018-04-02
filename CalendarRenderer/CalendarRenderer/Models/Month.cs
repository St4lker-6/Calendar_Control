using CalendarRenderer.Models.Events;
using CalendarRenderer.Models.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalendarRenderer.Models
{
    public class Month : INotifyPropertyChanged
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
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
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Weeks)));

                }
            }
        }

        #region Properties
        //public ObservableCollection<Week> Weeks { get; set; }
        public ObservableCollection<Day> DaysName { get; set; }
        public string NameMonth { get; private set; }
        public int NumberMonth { get; private set; }
        public int Year { get; private set; }
        public bool IsCurrentMonth { get; private set; }
        public ICommand MonthClickCommand { get; private set; }

        /// Need to be in public to be able to bind on
        public Color CurrentMonthColor { get; private set; }
        public Color TextColor { get; private set; }
        public Color CellColor { get; private set; }
        public DateTime CurrentDateTime { get; private set; }
        #endregion

        public Month(IEventAggregator eventAggregator, DependencyProperties dependencyProperties, DateTime dateTime, bool isCurrentMonth = false)
        {
            _eventAggregator = eventAggregator;

            if (dependencyProperties != null)
            {
                this.CurrentMonthColor = dependencyProperties.CurrentMonthColor;
                this.TextColor = dependencyProperties.TextColor;
                this.CellColor = dependencyProperties.CellColor;
            }

            this.CurrentDateTime = dateTime;
            this.NameMonth = dateTime.ToString(DateTimeHelper.monthFormat);
            this.NumberMonth = dateTime.Month;
            this.IsCurrentMonth = isCurrentMonth;
            this.Year = dateTime.Year;

            this.Weeks = new ObservableCollection<Week>();
            this.MonthClickCommand = new Command(this.MonthClicked);
        }

        private void MonthClicked()
        {
            _eventAggregator.GetEvent<MonthClickedEvent>().Publish(new MonthClickedEventArgs(this));
        }
    }
}
