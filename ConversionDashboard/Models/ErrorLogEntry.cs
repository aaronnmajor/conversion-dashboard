namespace ConversionDashboard.Models
{
    public class ErrorLogEntry
    {
        public string Timestamp { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string JobName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
    }
}
