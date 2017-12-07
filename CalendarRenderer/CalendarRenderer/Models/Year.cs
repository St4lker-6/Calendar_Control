using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models
{
    public class Year
    {
        public ObservableCollection<Month> Months { get; set; }
        public int NumberYear { get; set; }

        public Year()
        {
            Months = new ObservableCollection<Month>();
        }
    }
}
