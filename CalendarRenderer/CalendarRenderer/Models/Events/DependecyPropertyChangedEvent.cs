using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models.Events
{

    public class DependecyPropertyChangedEvent : PubSubEvent<DependecyPropertyChangedEventArgs> { }

    public class DependecyPropertyChangedEventArgs : EventArgs
    {
        public DependencyProperties DependecyProps { get; set; }

        public DependecyPropertyChangedEventArgs(DependencyProperties dependecyProperties)
        {
            this.DependecyProps = dependecyProperties;
        }
    }
}
