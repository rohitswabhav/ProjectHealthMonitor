using System.ComponentModel.DataAnnotations;

namespace ProjectHealthMonitor.DTOs
{
    public class UpdateProgressRequest
    {
        [Range(0, 100)]
        public double ProgressPercentage { get; set; }
    }
}
