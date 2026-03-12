using ProjectHealthMonitor.DTOs;
using ProjectHealthMonitor.Mapping;
using ProjectHealthMonitor.Repositories.Interfaces;
using ProjectHealthMonitor.Services.Interfaces;
using ProjectHealthMonitor.Domain;
using ProjectHealthMonitor.DTOs;
using Microsoft.Extensions.Logging;
namespace ProjectHealthMonitor.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository repository,
            ILogger<ProjectService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Guid> CreateProjectAsync(CreateProjectRequest dto)
        {
            _logger.LogInformation("Creating new project {ProjectName}", dto.Name);
            var project = ProjectMapper.ToEntity(dto);

            await _repository.AddAsync(project);

            _logger.LogInformation(
                "Project created {ProjectId}", project.Id);

            return project.Id;
        }



        public async Task<ProjectHealthResponse> GetHealthAsync(Guid id)
        {
            _logger.LogInformation("Calculating health for project {ProjectId}", id);

            var project = await _repository.GetAsync(id);

            if (project == null)
                throw new Exception("Project not found");

            var health = CalculateHealth(project);

            return new ProjectHealthResponse
            {
                ProjectId = project.Id,
                Progress = project.ProgressPercentage,
                BudgetUsedPercentage = (decimal)((project.ActualCost / project.Budget) * 100),
                HealthStatus = health
            };
        }
        private string CalculateHealth(Project project)
        {
            if (project.Budget <= 0)
                throw new ArgumentException("Budget must be greater than zero");

            if (project.ProgressPercentage < 0 || project.ProgressPercentage > 100)
                throw new ArgumentException("Progress must be between 0 and 100");

            var costPercentage = (double)(project.ActualCost / project.Budget * 100);

            if (project.ProgressPercentage >= costPercentage)
                return "Healthy";

            if (costPercentage - project.ProgressPercentage <= 10)
                return "Warning";

            return "Critical";
        }
    }
}
