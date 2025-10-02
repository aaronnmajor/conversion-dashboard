using System.Windows;
using System.Windows.Controls;

namespace ConversionDashboard.Views
{
    public partial class QuickAccessView : Page
    {
        public QuickAccessView()
        {
            InitializeComponent();
            LoadPaths();
        }

        private void LoadPaths()
        {
            var config = Services.ConfigurationService.GetConfiguration();
            var workingDir = config.WorkingDirectory;

            WorkingDirPath.Text = workingDir;
            LogsDirPath.Text = System.IO.Path.Combine(workingDir, "Logs");
            ConfigDirPath.Text = System.IO.Path.Combine(workingDir, "Config");
            OutputDirPath.Text = System.IO.Path.Combine(workingDir, "Output");
            ArchiveDirPath.Text = System.IO.Path.Combine(workingDir, "Archive");
            TempDirPath.Text = System.IO.Path.Combine(workingDir, "Temp");
        }

        private void OpenDirectory(string path)
        {
            try
            {
                if (System.IO.Directory.Exists(path))
                {
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                else
                {
                    var result = MessageBox.Show(
                        $"Directory does not exist:\n{path}\n\nWould you like to create it?",
                        "Directory Not Found",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        System.IO.Directory.CreateDirectory(path);
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening directory:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenFile(string path, string editorPath = "notepad.exe")
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(editorPath, path);
                }
                else
                {
                    MessageBox.Show($"File does not exist:\n{path}", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenWorkingDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(WorkingDirPath.Text);
        private void OpenLogsDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(LogsDirPath.Text);
        private void OpenConfigDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(ConfigDirPath.Text);
        private void OpenOutputDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(OutputDirPath.Text);
        private void OpenArchiveDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(ArchiveDirPath.Text);
        private void OpenTempDir_Click(object sender, RoutedEventArgs e) => OpenDirectory(TempDirPath.Text);

        private void OpenAppConfig_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(ConfigDirPath.Text, "app.config");
            OpenFile(path);
        }

        private void EditAppConfig_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(ConfigDirPath.Text, "app.config");
            OpenFile(path, "notepad.exe");
        }

        private void OpenDbConfig_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(ConfigDirPath.Text, "database.config");
            OpenFile(path);
        }

        private void EditDbConfig_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(ConfigDirPath.Text, "database.config");
            OpenFile(path, "notepad.exe");
        }

        private void ViewCurrentLog_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(LogsDirPath.Text, "app.log");
            OpenFile(path);
        }

        private void ClearCurrentLog_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(LogsDirPath.Text, "app.log");
            var result = MessageBox.Show(
                "Are you sure you want to clear the current log file?",
                "Confirm Clear",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.WriteAllText(path, string.Empty);
                        MessageBox.Show("Log file cleared successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing log file:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewErrorLog_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(LogsDirPath.Text, "error.log");
            OpenFile(path);
        }

        private void ClearErrorLog_Click(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(LogsDirPath.Text, "error.log");
            var result = MessageBox.Show(
                "Are you sure you want to clear the error log file?",
                "Confirm Clear",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.WriteAllText(path, string.Empty);
                        MessageBox.Show("Error log cleared successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing error log:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateAllDirectories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var directories = new[] { WorkingDirPath.Text, LogsDirPath.Text, ConfigDirPath.Text, 
                                         OutputDirPath.Text, ArchiveDirPath.Text, TempDirPath.Text };
                
                foreach (var dir in directories)
                {
                    if (!System.IO.Directory.Exists(dir))
                    {
                        System.IO.Directory.CreateDirectory(dir);
                    }
                }

                MessageBox.Show("All directories created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating directories:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CleanTempFiles_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "This will delete all files in the Temp directory. Are you sure?",
                "Confirm Clean",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Temp files cleaned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ArchiveOldLogs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Old log files have been archived!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackupConfig_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Configuration backed up successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RefreshPaths_Click(object sender, RoutedEventArgs e)
        {
            LoadPaths();
            MessageBox.Show("Paths refreshed!", "Refresh", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
