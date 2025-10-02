namespace ConversionDashboard.Models
{
    public class Configuration
    {
        public string AppName { get; set; } = "Conversion Dashboard";
        public string WorkingDirectory { get; set; } = @"C:\ConversionData";
        public string DatabaseServer { get; set; } = "localhost";
        public string DatabaseName { get; set; } = "ConversionDB";
        public string DatabaseUsername { get; set; } = "admin";
        public int ConnectionTimeout { get; set; } = 30;
        public bool AutoStart { get; set; } = false;
        public bool MinimizeToTray { get; set; } = false;
        public bool EnableNotifications { get; set; } = true;
        public bool EmailAlerts { get; set; } = true;
        public string EmailRecipients { get; set; } = "admin@example.com";
    }
}
