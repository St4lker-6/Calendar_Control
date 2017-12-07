using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models
{
    public class Week
    {
        public ObservableCollection<Day> Days { get; set; }

        public Week()
        {
            Days = new ObservableCollection<Day>();
        }
    }
}
