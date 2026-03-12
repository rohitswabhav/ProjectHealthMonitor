namespace ProjectHealthMonitor.DTOs
{
    public class ProjectHealthResponse
    {
        public Guid ProjectId { get; set; }

        public double Progress { get; set; }

        public decimal BudgetUsedPercentage { get; set; }

        public string HealthStatus { get; set; }
    }
}
