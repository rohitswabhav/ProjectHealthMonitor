namespace ProjectHealthMonitor.Domain
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public decimal ActualCost { get; set; }

        public double ProgressPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}