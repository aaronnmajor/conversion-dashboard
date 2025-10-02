namespace ConversionDashboard.Models
{
    public class QueuedJob
    {
        public int Position { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string QueuedAt { get; set; } = string.Empty;
        public string EstimatedSize { get; set; } = string.Empty;
        public string SubmittedBy { get; set; } = string.Empty;
    }
}
