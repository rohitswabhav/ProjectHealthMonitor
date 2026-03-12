
    using global::ProjectHealthMonitor.Domain;
    using global::ProjectHealthMonitor.DTOs;
    using ProjectHealthMonitor.Domain;
    using ProjectHealthMonitor.DTOs;

    namespace ProjectHealthMonitor.Mapping;

    public static class ProjectMapper
    {
        public static Project ToEntity(CreateProjectRequest dto)
        {
            return new Project
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Budget = dto.Budget,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ActualCost = 50000,
                ProgressPercentage = 60
            };
        }
    }

