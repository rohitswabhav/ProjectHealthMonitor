using System.ComponentModel.DataAnnotations;

namespace ProjectHealthMonitor.DTOs
{
    public class UpdateCostRequest
    {
        [Range(0, double.MaxValue)]
        public decimal ActualCost { get; set; }
    }
}
