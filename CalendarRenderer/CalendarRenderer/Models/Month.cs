using CalendarRenderer.Models.Events;
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
    public class Month
    {
        #region Fields
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Properties
        public ObservableCollection<Week> Weeks { get; set; }
        public string NameMonth { get; private set; }
        public int NumberMonth { get; private set; }
        public int Year { get; private set; }
        public bool IsCurrentMonth { get; private set; }
        public ICommand MonthClickCommand{ get; private set; }

        private Color CurrentMonthColor { get; set; }
        private Color TextColor { get; set; }
        private Color CellColor { get; set; }
        #endregion

        public Month(IEventAggregator eventAggregator, DependencyProperties dependencyProperties, int numberMonth, string nameMonth, int year, bool isCurrentMonth = false)
        {
            _eventAggregator = eventAggregator;

            if (dependencyProperties != null)
            {
                this.CurrentMonthColor = dependencyProperties.CurrentMonthColor;
                this.TextColor = dependencyProperties.TextColor;
                this.CellColor = dependencyProperties.CellColor;
            }

            this.NameMonth = nameMonth;
            this.NumberMonth = numberMonth;
            this.IsCurrentMonth = isCurrentMonth;
            this.Year = year;

            Weeks = new ObservableCollection<Week>();
            this.MonthClickCommand = new Command(this.MonthClicked);
        }

        private void MonthClicked()
        {
            _eventAggregator.GetEvent<MonthClickedEvent>().Publish(new MonthClickedEventArgs(this));
        }
    }
}
