using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ConversionDashboard.Models;

namespace ConversionDashboard.Views
{
    public partial class JobsView : Page
    {
        private ObservableCollection<JobInfo> _jobs = new ObservableCollection<JobInfo>();

        public JobsView()
        {
            InitializeComponent();
            LoadJobs();
        }

        private void LoadJobs()
        {
            _jobs = new ObservableCollection<JobInfo>
            {
                new JobInfo
                {
                    JobId = 1,
                    JobName = "Daily Data Conversion",
                    Status = "Running",
                    Progress = "75%",
                    StartTime = DateTime.Now.AddHours(-2).ToString("MM/dd/yyyy HH:mm"),
                    Duration = "02:15:30",
                    RecordsProcessed = "15,234 / 20,000",
                    JobType = "Batch Conversion",
                    LastMessage = "Processing batch 3 of 4..."
                },
                new JobInfo
                {
                    JobId = 2,
                    JobName = "Customer Data Migration",
                    Status = "Completed",
                    Progress = "100%",
                    StartTime = DateTime.Now.AddHours(-5).ToString("MM/dd/yyyy HH:mm"),
                    Duration = "01:45:20",
                    RecordsProcessed = "50,000 / 50,000",
                    JobType = "Migration",
                    LastMessage = "Job completed successfully."
                },
                new JobInfo
                {
                    JobId = 3,
                    JobName = "Inventory Update",
                    Status = "Failed",
                    Progress = "45%",
                    StartTime = DateTime.Now.AddHours(-3).ToString("MM/dd/yyyy HH:mm"),
                    Duration = "00:30:15",
                    RecordsProcessed = "9,000 / 20,000",
                    JobType = "Update",
                    LastMessage = "Error: Connection timeout to database."
                },
                new JobInfo
                {
                    JobId = 4,
                    JobName = "Weekly Report Generation",
                    Status = "Pending",
                    Progress = "0%",
                    StartTime = "-",
                    Duration = "-",
                    RecordsProcessed = "0 / 0",
                    JobType = "Report",
                    LastMessage = "Scheduled to run at 11:00 PM."
                },
                new JobInfo
                {
                    JobId = 5,
                    JobName = "Data Validation",
                    Status = "Completed",
                    Progress = "100%",
                    StartTime = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy HH:mm"),
                    Duration = "00:15:45",
                    RecordsProcessed = "100,000 / 100,000",
                    JobType = "Validation",
                    LastMessage = "Validation completed with 0 errors."
                }
            };

            JobsDataGrid.ItemsSource = _jobs;
        }

        private void JobsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (JobsDataGrid.SelectedItem is JobInfo job)
            {
                DetailJobName.Text = job.JobName;
                DetailJobType.Text = job.JobType;
                DetailStatus.Text = job.Status;
                DetailLastRun.Text = job.StartTime;
                DetailDuration.Text = job.Duration;
                DetailRecordsProcessed.Text = job.RecordsProcessed;
                DetailLastMessage.Text = job.LastMessage;

                // Parse progress percentage
                if (job.Progress.EndsWith("%") && double.TryParse(job.Progress.TrimEnd('%'), out double progress))
                {
                    DetailProgressBar.Value = progress;
                }

                // Update status color
                DetailStatus.Foreground = job.Status switch
                {
                    "Running" => (System.Windows.Media.Brush)FindResource("SuccessBrush"),
                    "Completed" => (System.Windows.Media.Brush)FindResource("AccentBrush"),
                    "Failed" => (System.Windows.Media.Brush)FindResource("DangerBrush"),
                    "Pending" => (System.Windows.Media.Brush)FindResource("WarningBrush"),
                    _ => (System.Windows.Media.Brush)FindResource("SecondaryTextBrush")
                };
            }
        }

        private void RunJob_Click(object sender, RoutedEventArgs e)
        {
            if (JobsDataGrid.SelectedItem is JobInfo job)
            {
                MessageBox.Show(
                    $"Starting job: {job.JobName}\n\nThe job will begin processing shortly.",
                    "Run Job",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                
                // Simulate job start
                job.Status = "Running";
                job.StartTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                JobsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a job to run.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void PauseJob_Click(object sender, RoutedEventArgs e)
        {
            if (JobsDataGrid.SelectedItem is JobInfo job)
            {
                if (job.Status == "Running")
                {
                    MessageBox.Show(
                        $"Pausing job: {job.JobName}",
                        "Pause Job",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Only running jobs can be paused.", "Invalid Status", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a job to pause.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StopJob_Click(object sender, RoutedEventArgs e)
        {
            if (JobsDataGrid.SelectedItem is JobInfo job)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to stop job: {job.JobName}?\n\nThis action cannot be undone.",
                    "Stop Job",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    job.Status = "Stopped";
                    JobsDataGrid.Items.Refresh();
                    MessageBox.Show("Job stopped successfully.", "Stopped", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a job to stop.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshJobs_Click(object sender, RoutedEventArgs e)
        {
            LoadJobs();
            MessageBox.Show("Job list refreshed!", "Refresh", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewJobLogs_Click(object sender, RoutedEventArgs e)
        {
            if (JobsDataGrid.SelectedItem is JobInfo job)
            {
                MessageBox.Show(
                    $"Opening logs for job: {job.JobName}\n\nLog file: C:\\ConversionData\\Logs\\job_{job.JobId}.log",
                    "View Logs",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a job to view logs.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateNewJob_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Create New Job wizard would open here.\n\nYou would be able to configure:\n- Job name and type\n- Schedule\n- Data source and destination\n- Conversion rules",
                "Create New Job",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
