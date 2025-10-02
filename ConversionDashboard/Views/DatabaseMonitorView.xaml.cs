using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ConversionDashboard.Models;

namespace ConversionDashboard.Views
{
    public partial class DatabaseMonitorView : Page
    {
        private DispatcherTimer? _refreshTimer;
        private ObservableCollection<ActiveConversion> _activeConversions;
        private ObservableCollection<QueuedJob> _queuedJobs;
        private ObservableCollection<ErrorLogEntry> _errorLog;

        public DatabaseMonitorView()
        {
            InitializeComponent();
            
            _activeConversions = new ObservableCollection<ActiveConversion>();
            _queuedJobs = new ObservableCollection<QueuedJob>();
            _errorLog = new ObservableCollection<ErrorLogEntry>();
            
            LoadData();
            SetupAutoRefresh();
        }

        private void SetupAutoRefresh()
        {
            _refreshTimer = new DispatcherTimer();
            _refreshTimer.Tick += RefreshTimer_Tick;
            UpdateRefreshInterval();
        }

        private void UpdateRefreshInterval()
        {
            if (_refreshTimer == null) return;

            _refreshTimer.Stop();

            if (AutoRefreshCheckBox.IsChecked == true)
            {
                var interval = RefreshIntervalComboBox.SelectedIndex switch
                {
                    0 => TimeSpan.FromSeconds(5),
                    1 => TimeSpan.FromSeconds(10),
                    2 => TimeSpan.FromSeconds(30),
                    3 => TimeSpan.FromSeconds(60),
                    _ => TimeSpan.FromSeconds(10)
                };

                _refreshTimer.Interval = interval;
                _refreshTimer.Start();
            }
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LoadActiveConversions();
            LoadQueuedJobs();
            LoadErrorLog();
            LoadStatistics();
            
            LastRefreshText.Text = $"Last refresh: {DateTime.Now:HH:mm:ss}";
        }

        private void LoadActiveConversions()
        {
            _activeConversions.Clear();
            
            // Simulate active conversions data
            _activeConversions.Add(new ActiveConversion
            {
                Id = 1001,
                JobName = "Customer Data Migration",
                Status = "Running",
                StartTime = DateTime.Now.AddMinutes(-45).ToString("MM/dd/yyyy HH:mm:ss"),
                Elapsed = "00:45:23",
                Progress = "67%",
                User = "admin"
            });

            _activeConversions.Add(new ActiveConversion
            {
                Id = 1002,
                JobName = "Product Catalog Update",
                Status = "Running",
                StartTime = DateTime.Now.AddMinutes(-15).ToString("MM/dd/yyyy HH:mm:ss"),
                Elapsed = "00:15:10",
                Progress = "34%",
                User = "system"
            });

            _activeConversions.Add(new ActiveConversion
            {
                Id = 1003,
                JobName = "Order History Import",
                Status = "Running",
                StartTime = DateTime.Now.AddMinutes(-5).ToString("MM/dd/yyyy HH:mm:ss"),
                Elapsed = "00:05:45",
                Progress = "12%",
                User = "admin"
            });

            ActiveConversionsGrid.ItemsSource = _activeConversions;
        }

        private void LoadQueuedJobs()
        {
            _queuedJobs.Clear();
            
            // Simulate queued jobs data
            _queuedJobs.Add(new QueuedJob
            {
                Position = 1,
                JobName = "Weekly Sales Report",
                Priority = "High",
                QueuedAt = DateTime.Now.AddMinutes(-30).ToString("MM/dd/yyyy HH:mm:ss"),
                EstimatedSize = "2.5 GB",
                SubmittedBy = "user1"
            });

            _queuedJobs.Add(new QueuedJob
            {
                Position = 2,
                JobName = "Employee Database Sync",
                Priority = "Medium",
                QueuedAt = DateTime.Now.AddMinutes(-25).ToString("MM/dd/yyyy HH:mm:ss"),
                EstimatedSize = "500 MB",
                SubmittedBy = "admin"
            });

            _queuedJobs.Add(new QueuedJob
            {
                Position = 3,
                JobName = "Archive Old Records",
                Priority = "Low",
                QueuedAt = DateTime.Now.AddMinutes(-10).ToString("MM/dd/yyyy HH:mm:ss"),
                EstimatedSize = "10 GB",
                SubmittedBy = "system"
            });

            QueuedJobsGrid.ItemsSource = _queuedJobs;
        }

        private void LoadErrorLog()
        {
            _errorLog.Clear();
            
            // Simulate error log data
            _errorLog.Add(new ErrorLogEntry
            {
                Timestamp = DateTime.Now.AddMinutes(-120).ToString("MM/dd/yyyy HH:mm:ss"),
                Severity = "Error",
                JobName = "Inventory Update",
                Message = "Connection timeout while connecting to remote database",
                ErrorCode = "E1001"
            });

            _errorLog.Add(new ErrorLogEntry
            {
                Timestamp = DateTime.Now.AddMinutes(-90).ToString("MM/dd/yyyy HH:mm:ss"),
                Severity = "Warning",
                JobName = "Data Validation",
                Message = "Found 15 records with invalid format",
                ErrorCode = "W2003"
            });

            _errorLog.Add(new ErrorLogEntry
            {
                Timestamp = DateTime.Now.AddMinutes(-60).ToString("MM/dd/yyyy HH:mm:ss"),
                Severity = "Error",
                JobName = "Customer Data Migration",
                Message = "Duplicate key violation on customer_id field",
                ErrorCode = "E1045"
            });

            _errorLog.Add(new ErrorLogEntry
            {
                Timestamp = DateTime.Now.AddMinutes(-30).ToString("MM/dd/yyyy HH:mm:ss"),
                Severity = "Warning",
                JobName = "Product Catalog Update",
                Message = "High memory usage detected (85%)",
                ErrorCode = "W3001"
            });

            ErrorLogGrid.ItemsSource = _errorLog;
        }

        private void LoadStatistics()
        {
            // Simulate loading statistics
            TotalConversionsText.Text = "1,234";
            SuccessRateText.Text = "97.5%";
            AvgDurationText.Text = "00:15:30";
            FailedTodayText.Text = "5";
            RecordsProcessedText.Text = "5.2M";
            DataVolumeText.Text = "128 GB";
        }

        private void AutoRefresh_Changed(object sender, RoutedEventArgs e)
        {
            UpdateRefreshInterval();
        }

        private void RefreshInterval_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateRefreshInterval();
        }

        private void RefreshNow_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExportData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Export functionality would save the current data to CSV or Excel format.\n\nFile will be saved to: C:\\ConversionData\\Exports\\",
                "Export Data",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void ConfigureQuery_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Query Configuration Dialog\n\nHere you would be able to:\n- Modify database queries\n- Add custom filters\n- Configure data sources\n- Set up custom reports",
                "Configure Query",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void ClearErrors_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to clear all error log entries?",
                "Clear Error Log",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _errorLog.Clear();
                MessageBox.Show("Error log cleared successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
