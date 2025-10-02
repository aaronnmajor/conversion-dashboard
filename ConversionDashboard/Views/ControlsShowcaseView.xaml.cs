using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ConversionDashboard.Views
{
    public partial class ControlsShowcaseView : Page
    {
        public ControlsShowcaseView()
        {
            InitializeComponent();
            
            // Set up event handlers
            SampleSlider.ValueChanged += SampleSlider_ValueChanged;
            
            // Set default dates
            SampleDatePicker.SelectedDate = DateTime.Now;
            SampleCalendar.SelectedDate = DateTime.Now;
            
            // Load sample data for DataGrid
            LoadSampleData();
        }

        private void SampleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderValueText != null)
            {
                SliderValueText.Text = $"Value: {(int)e.NewValue}";
            }
        }

        private void LoadSampleData()
        {
            var sampleData = new ObservableCollection<SampleDataItem>
            {
                new SampleDataItem { Id = 1, Name = "Sample Item 1", Status = "Active", IsActive = true },
                new SampleDataItem { Id = 2, Name = "Sample Item 2", Status = "Inactive", IsActive = false },
                new SampleDataItem { Id = 3, Name = "Sample Item 3", Status = "Active", IsActive = true },
                new SampleDataItem { Id = 4, Name = "Sample Item 4", Status = "Pending", IsActive = false },
                new SampleDataItem { Id = 5, Name = "Sample Item 5", Status = "Active", IsActive = true }
            };

            SampleDataGrid.ItemsSource = sampleData;
        }
    }

    public class SampleDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
