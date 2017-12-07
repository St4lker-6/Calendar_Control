using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarRenderer.Controls
{
    public class LabelButton : Button
    {
        //Bindable property for the progress color
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create("ProgressColor", typeof(string), typeof(LabelButton), defaultBindingMode: BindingMode.TwoWay);

        //Gets or sets the color of the progress bar
        public string ProgressColor
        {
            get { return (string)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value);
                }
        }

        //public static void OnItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    ((LabelButton)bindable).OnItemSourceChanged((IList<string>)oldValue, (IList<string>)newValue);
        //}

        //public void OnItemSourceChanged(IList<string> oldValue, IList<string> newValue)
        //{
        //    // Do your stuff in your object's/page's instance
        //}
    }
}
