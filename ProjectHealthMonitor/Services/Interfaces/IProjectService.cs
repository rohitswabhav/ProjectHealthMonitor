using ProjectHealthMonitor.DTOs;

namespace ProjectHealthMonitor.Services.Interfaces
{
    public interface IProjectService
    {
        public  Task<Guid> CreateProjectAsync(CreateProjectRequest dto);
        public  Task<ProjectHealthResponse> GetHealthAsync(Guid id);
    }
}
