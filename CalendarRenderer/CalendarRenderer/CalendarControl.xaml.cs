using CalendarRenderer.Models;
using CalendarRenderer.Models.Services;
using CalendarRenderer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Events;
using CalendarRenderer.Models.Events;

namespace CalendarRenderer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarControl : ContentView
    {
        private static IEventAggregator _eventAggregator;

        public CalendarControl()
        {
            InitializeComponent();

            _eventAggregator = ApplicationService.Instance.EventAggregator;
            _eventAggregator.GetEvent<DayClickedEvent>().Subscribe(DayClicked);

            this.BindingContext = new MainPageViewModel(_eventAggregator);
        }

        private DependencyProperties DependecyProp { get; set; }

        #region Dependecy property
        public static readonly BindableProperty CurrentDayColorProperty = BindableProperty.Create("CurrentDayColor",
                                                                                           typeof(Color),
                                                                                           typeof(CalendarControl),
                                                                                           defaultValue: Color.White,
                                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                                           propertyChanged: OnDependecyPropertyChanged);
        /// <summary>
        /// Defines the outline and text color of the current day
        /// </summary>
        public Color CurrentDayColor
        {
            get { return (Color)GetValue(CurrentDayColorProperty); }
            set
            {
                SetValue(CurrentDayColorProperty, value);
            }
        }

        public static readonly BindableProperty CurrentMonthColorProperty = BindableProperty.Create("CurrentMonthColor",
                                                                                           typeof(Color),
                                                                                           typeof(CalendarControl),
                                                                                           defaultValue: Color.White,
                                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                                           propertyChanged: OnDependecyPropertyChanged);
        /// <summary>
        /// Defines the outline and text color of the current month
        /// </summary>
        public Color CurrentMonthColor
        {
            get { return (Color)GetValue(CurrentMonthColorProperty); }
            set
            {
                SetValue(CurrentMonthColorProperty, value);
            }
        }

        public static readonly BindableProperty CellColorProperty = BindableProperty.Create("CellColor",
                                                                                           typeof(Color),
                                                                                           typeof(CalendarControl),
                                                                                           defaultValue: Color.Black,
                                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                                           propertyChanged: OnDependecyPropertyChanged);
        /// <summary>
        /// Defines the color of the day or month cell
        /// </summary>
        public Color CellColor
        {
            get { return (Color)GetValue(CellColorProperty); }
            set
            {
                SetValue(CellColorProperty, value);
            }
        }

        public static readonly BindableProperty CellBackgroundColorProperty = BindableProperty.Create("CellBackgroundColor",
                                                                                           typeof(Color),
                                                                                           typeof(CalendarControl),
                                                                                           defaultValue: Color.White,
                                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                                           propertyChanged: OnDependecyPropertyChanged);
        /// <summary>
        /// Defines the backgound of the calendar
        /// </summary>
        public Color CellBackgroundColor
        {
            get { return (Color)GetValue(CellBackgroundColorProperty); }
            set
            {
                SetValue(CellBackgroundColorProperty, value);
            }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor",
                                                                                           typeof(Color),
                                                                                           typeof(CalendarControl),
                                                                                           defaultValue: Color.White,
                                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                                           propertyChanged: OnDependecyPropertyChanged);
        /// <summary>
        /// Defines the 
        /// </summary>
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        /// <summary>
        /// Event raised when the user clicked on a specific day
        /// </summary>
        public event EventHandler DayClickedEvent;


        #endregion

        /// <summary>
        /// Method executed when a click on a day is realized
        /// </summary>
        private void DayClicked(DayClickedEventArgs obj)
        {
            if (DayClickedEvent != null)
                this.DayClickedEvent(this, obj);
        }

        /// <summary>
        /// Method executed when a dependecy property changed
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnDependecyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = (CalendarControl)bindable;

            /// Instanciate the object one time to not lose previous data
            if (self.DependecyProp == null)
                self.DependecyProp = new DependencyProperties();

            self.DependecyProp.CurrentDayColor = self.CurrentDayColor;
            self.DependecyProp.CurrentMonthColor = self.CurrentMonthColor;
            self.DependecyProp.CellColor = self.CellColor;
            self.DependecyProp.CellBackgroundColor = self.CellBackgroundColor;
            self.DependecyProp.TextColor = self.TextColor;

            /// Raise event to notify other view that a dependecy property changed
            _eventAggregator.GetEvent<DependecyPropertyChangedEvent>().Publish(new DependecyPropertyChangedEventArgs(self.DependecyProp));
        }
    }
}