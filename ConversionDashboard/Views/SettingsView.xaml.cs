using System.Windows;
using System.Windows.Controls;
using ConversionDashboard.Services;
using Microsoft.Win32;

namespace ConversionDashboard.Views
{
    public partial class SettingsView : Page
    {
        public SettingsView()
        {
            InitializeComponent();
            LoadSettings();
            
            // Set up event handlers
            TimeoutSlider.ValueChanged += TimeoutSlider_ValueChanged;
        }

        private void LoadSettings()
        {
            var config = ConfigurationService.GetConfiguration();
            
            AppNameTextBox.Text = config.AppName;
            WorkingDirTextBox.Text = config.WorkingDirectory;
            DbServerTextBox.Text = config.DatabaseServer;
            DbNameTextBox.Text = config.DatabaseName;
            DbUsernameTextBox.Text = config.DatabaseUsername;
            TimeoutSlider.Value = config.ConnectionTimeout;
            AutoStartCheckBox.IsChecked = config.AutoStart;
            MinimizeToTrayCheckBox.IsChecked = config.MinimizeToTray;
            EnableNotificationsCheckBox.IsChecked = config.EnableNotifications;
            EmailAlertsCheckBox.IsChecked = config.EmailAlerts;
            EmailRecipientsTextBox.Text = config.EmailRecipients;
            
            UpdateTimeoutDisplay();
        }

        private void TimeoutSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateTimeoutDisplay();
        }

        private void UpdateTimeoutDisplay()
        {
            if (TimeoutValueText != null)
            {
                TimeoutValueText.Text = $"{(int)TimeoutSlider.Value} seconds";
            }
        }

        private void BrowseWorkingDir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select Working Directory",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Select Folder"
            };

            if (dialog.ShowDialog() == true)
            {
                var path = System.IO.Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(path))
                {
                    WorkingDirTextBox.Text = path;
                }
            }
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            var server = DbServerTextBox.Text;
            var database = DbNameTextBox.Text;
            var username = DbUsernameTextBox.Text;
            
            // Simulate connection test
            MessageBox.Show(
                $"Testing connection to:\nServer: {server}\nDatabase: {database}\nUser: {username}\n\nConnection successful!",
                "Database Connection Test",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            var config = new Models.Configuration
            {
                AppName = AppNameTextBox.Text,
                WorkingDirectory = WorkingDirTextBox.Text,
                DatabaseServer = DbServerTextBox.Text,
                DatabaseName = DbNameTextBox.Text,
                DatabaseUsername = DbUsernameTextBox.Text,
                ConnectionTimeout = (int)TimeoutSlider.Value,
                AutoStart = AutoStartCheckBox.IsChecked ?? false,
                MinimizeToTray = MinimizeToTrayCheckBox.IsChecked ?? false,
                EnableNotifications = EnableNotificationsCheckBox.IsChecked ?? false,
                EmailAlerts = EmailAlertsCheckBox.IsChecked ?? false,
                EmailRecipients = EmailRecipientsTextBox.Text
            };

            ConfigurationService.SaveConfiguration(config);
            
            MessageBox.Show(
                "Settings saved successfully!",
                "Success",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void ResetSettings_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to reset all settings to default values?",
                "Reset Settings",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ConfigurationService.ResetToDefaults();
                LoadSettings();
                
                MessageBox.Show(
                    "Settings have been reset to default values.",
                    "Reset Complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
