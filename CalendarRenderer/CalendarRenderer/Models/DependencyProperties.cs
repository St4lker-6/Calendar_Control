using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarRenderer.Models
{
    /// <summary>
    /// Class regrouping all dependency properties of the calendar control
    /// Use to pass properties between views
    /// </summary>
    public class DependencyProperties
    {
        public Color CurrentDayColor { get; set; }
        public Color CurrentMonthColor { get; set; }
        public Color CellColor { get; set; }
        public Color CellBackgroundColor { get; set; }
        public Color TextColor { get; set; }

        public ObservableCollection<DayActivity> Activities { get; set; }
    }
}
