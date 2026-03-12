using ProjectHealthMonitor.Domain;
using ProjectHealthMonitor.Repositories.Interfaces;
using System.Collections.Concurrent;
namespace ProjectHealthMonitor.Repositories.Implementations
{
    

    public class ProjectRepository : IProjectRepository
    {
        private readonly ConcurrentDictionary<Guid, Project> _projects = new();

        public Task<Project> AddAsync(Project project)
        {
            _projects[project.Id] = project;
            return Task.FromResult(project);
        }

        public Task<Project> GetAsync(Guid id)
        {
            _projects.TryGetValue(id, out var project);
            return Task.FromResult(project);
        }

        public Task UpdateAsync(Project project)
        {
            _projects[project.Id] = project;
            return Task.CompletedTask;
        }
    }
}
