using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CalendarRenderer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarGridView : ContentView
    {

        public CalendarGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method executed when the user click on a list view row
        /// Use to disable the highlight when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }
    }
}