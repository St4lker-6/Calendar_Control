using CalendarRenderer.Models;
using CalendarSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalendarSample.ViewModels
{
    public class DayDetailPageViewModel : ViewModelBase
    {
        private DateTime _currentDateTime;
        private Dictionary<string, Color> _nameToColor;

        public ICommand AddActivityCommand { get; protected set; }

        private string _activityText;
        public string ActivityText
        {

            get
            {
                return _activityText;
            }
            set
            {
                _activityText = value;
                this.OnPropertyChanged(nameof(ActivityText));
                ((Command)this.AddActivityCommand).ChangeCanExecute();
            }
        }

        private ObservableCollection<DayActivity> _activities;
        public ObservableCollection<DayActivity> Activities
        {

            get
            {
                return _activities;
            }
            set
            {
                _activities = value;
                this.OnPropertyChanged(nameof(Activities));
            }
        }

        private ObservableCollection<ColorClass> _colorList;
        public ObservableCollection<ColorClass> ColorList
        {

            get
            {
                return _colorList;
            }
            set
            {
                _colorList = value;
                this.OnPropertyChanged(nameof(ColorList));
            }
        }

        private ColorClass _selectedColor;
        public ColorClass SelectedColor
        {

            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                this.OnPropertyChanged(nameof(SelectedColor));
            }
        }

        public DayDetailPageViewModel(CalendarRenderer.Models.Day clickedDay)
        {
            this.AddActivityCommand = new Command(this.AddActivity, this.CanAddActivity);
            this.Activities = new ObservableCollection<DayActivity>();

            _currentDateTime = clickedDay.CurrentDateTime;

            this.ColorList = new ObservableCollection<ColorClass>();

            _nameToColor = this.LoadColor();

            foreach (var nameColor in _nameToColor)
            {
                this.ColorList.Add(new ColorClass(nameColor.Key, nameColor.Value));
            }

            this.SelectedColor = this.ColorList.FirstOrDefault(c => c.Color == Color.Red);
        }

        private Dictionary<string, Color> LoadColor()
        {
            // Dictionary to get Color from color name.
            return new Dictionary<string, Color>
            {
                { "Aqua", Color.Aqua },
                { "Black", Color.Black },
                { "Blue", Color.Blue },
                { "Gray", Color.Gray },
                { "Green", Color.Green },
                { "Lime", Color.Lime },
                { "Maroon", Color.Maroon },
                { "Navy", Color.Navy },
                { "Olive", Color.Olive },
                { "Purple", Color.Purple },
                { "Red", Color.Red },
                { "Silver", Color.Silver },
                { "Teal", Color.Teal },
                { "White", Color.White },
                { "Yellow", Color.Yellow }
            };
        }

        private bool CanAddActivity()
        {
            return !string.IsNullOrEmpty(this.ActivityText) && !string.IsNullOrWhiteSpace(this.ActivityText);
        }

        private void AddActivity()
        {
            this.Activities.Add(new DayActivity(_currentDateTime, this.ActivityText, this.SelectedColor.Color));

            Application.Current.MainPage.Navigation.PopAsync();
        }

    }



}

