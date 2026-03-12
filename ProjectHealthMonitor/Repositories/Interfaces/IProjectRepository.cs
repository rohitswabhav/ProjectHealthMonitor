using ProjectHealthMonitor.Domain;

namespace ProjectHealthMonitor.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        public Task<Project> AddAsync(Project project);
        public Task<Project> GetAsync(Guid id);
        public Task UpdateAsync(Project project);

    }
}
