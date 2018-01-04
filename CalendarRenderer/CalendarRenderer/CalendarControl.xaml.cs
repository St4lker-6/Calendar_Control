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

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }
        #endregion

        static void OnDependecyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = (CalendarControl)bindable;

            if (self.DependecyProp == null)
                self.DependecyProp = new DependencyProperties();

            self.DependecyProp.CurrentDayColor = self.CurrentDayColor;
            self.DependecyProp.CurrentMonthColor = self.CurrentMonthColor;
            self.DependecyProp.CellColor = self.CellColor;
            self.DependecyProp.CellBackgroundColor = self.CellBackgroundColor;
            self.DependecyProp.TextColor = self.TextColor;
            _eventAggregator.GetEvent<DependecyPropertyChangedEvent>().Publish(new DependecyPropertyChangedEventArgs(self.DependecyProp));
        }
    }
}