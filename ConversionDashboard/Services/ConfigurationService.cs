using System.IO;
using System.Text.Json;
using ConversionDashboard.Models;

namespace ConversionDashboard.Services
{
    public static class ConfigurationService
    {
        private static Configuration? _configuration;
        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ConversionDashboard",
            "config.json");

        public static void Initialize()
        {
            try
            {
                var configDir = Path.GetDirectoryName(ConfigFilePath);
                if (!string.IsNullOrEmpty(configDir) && !Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                }

                if (File.Exists(ConfigFilePath))
                {
                    var json = File.ReadAllText(ConfigFilePath);
                    _configuration = JsonSerializer.Deserialize<Configuration>(json);
                }

                if (_configuration == null)
                {
                    _configuration = new Configuration();
                    SaveConfiguration(_configuration);
                }
            }
            catch
            {
                _configuration = new Configuration();
            }
        }

        public static Configuration GetConfiguration()
        {
            if (_configuration == null)
            {
                Initialize();
            }
            return _configuration ?? new Configuration();
        }

        public static void SaveConfiguration(Configuration config)
        {
            try
            {
                _configuration = config;
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(config, options);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(
                    $"Failed to save configuration: {ex.Message}",
                    "Configuration Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
        }

        public static void ResetToDefaults()
        {
            _configuration = new Configuration();
            SaveConfiguration(_configuration);
        }
    }
}
