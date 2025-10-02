namespace ConversionDashboard.Models
{
    public class JobInfo
    {
        public int JobId { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Progress { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string RecordsProcessed { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty;
        public string LastMessage { get; set; } = string.Empty;
    }
}
