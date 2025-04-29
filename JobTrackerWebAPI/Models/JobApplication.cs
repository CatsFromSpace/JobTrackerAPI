namespace JobTrackerWebAPI.Models
{
    public class JobApplication // App model
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime? DateInterviewed { get; set; }
        public string Notes { get; set; }
    }
}
