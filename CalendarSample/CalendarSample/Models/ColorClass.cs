using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarSample.Models
{
    public class ColorClass
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }

        public ColorClass(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
