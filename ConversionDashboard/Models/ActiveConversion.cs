namespace ConversionDashboard.Models
{
    public class ActiveConversion
    {
        public int Id { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string Elapsed { get; set; } = string.Empty;
        public string Progress { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
    }
}
