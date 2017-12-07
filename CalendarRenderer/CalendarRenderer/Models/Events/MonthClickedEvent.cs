using CalendarRenderer.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models.Events
{
    public class MonthClickedEvent : PubSubEvent<MonthClickedEventArgs> { }

    public class MonthClickedEventArgs : EventArgs
    {
        public Month ClickedMonth { get; set; }

        public MonthClickedEventArgs(Month clickedMonth)
        {
            ClickedMonth = clickedMonth;
        }
    }
}
