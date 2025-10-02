using System.Windows;

namespace ConversionDashboard
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Initialize configuration and services
            Services.ConfigurationService.Initialize();
        }
    }
}
