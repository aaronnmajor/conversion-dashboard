using System.Windows;
using System.Windows.Controls;

namespace ConversionDashboard.Views
{
    public partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Simulate loading dashboard statistics
            TotalJobsText.Text = "127";
            ActiveJobsText.Text = "12";
            FailedJobsText.Text = "3";
            DbStatusText.Text = "Connected";
        }

        private void RunConversion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Starting conversion job...", "Run Conversion", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewLogs_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                // This would navigate to the Quick Access page
                MessageBox.Show("Navigating to logs...", "View Logs", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RefreshStats_Click(object sender, RoutedEventArgs e)
        {
            LoadDashboardData();
            MessageBox.Show("Dashboard statistics refreshed!", "Refresh", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                // This would navigate to the Settings page
                MessageBox.Show("Opening settings...", "Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
