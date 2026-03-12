using System.ComponentModel.DataAnnotations;

namespace ProjectHealthMonitor.DTOs
{
    public class CreateProjectRequest
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
