using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models.Events
{
    public class DayClickedEvent : PubSubEvent<DayClickedEventArgs> { }

    public class DayClickedEventArgs : EventArgs
    {
        public Day ClickedDay { get; set; }

        public DayClickedEventArgs(Day clickedDay)
        {
            ClickedDay = clickedDay;
        }
    }
}
