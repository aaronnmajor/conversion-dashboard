using System.Windows;
using System.Windows.Controls;
using ConversionDashboard.Views;

namespace ConversionDashboard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Navigate to Dashboard by default
            NavigateTo(new DashboardView());
        }

        private void NavigateTo(Page page)
        {
            ContentFrame.Navigate(page);
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new DashboardView());
            UpdateStatus("Dashboard loaded");
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new SettingsView());
            UpdateStatus("Settings loaded");
        }

        private void QuickAccessButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new QuickAccessView());
            UpdateStatus("Quick Access loaded");
        }

        private void JobsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new JobsView());
            UpdateStatus("Jobs loaded");
        }

        private void DatabaseMonitorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new DatabaseMonitorView());
            UpdateStatus("Database Monitor loaded");
        }

        private void ControlsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new ControlsShowcaseView());
            UpdateStatus("Controls Showcase loaded");
        }

        private void UpdateStatus(string status)
        {
            StatusText.Text = status;
        }
    }
}
