using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarRenderer.Models
{
    public class DayActivity
    {
        public DateTime CurrentDateTime { get; private set; }
        public Color Color { get; private set; }
        public string Name { get; private set; }

        public DayActivity(DateTime currentDatetime, string name, Color color)
        {
            this.CurrentDateTime = currentDatetime;
            this.Name = name;
            this.Color = color;
        }
    }
}
