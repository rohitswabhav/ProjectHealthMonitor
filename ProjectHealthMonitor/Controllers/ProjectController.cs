using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectHealthMonitor.DTOs;
using ProjectHealthMonitor.Infrastructure;
using ProjectHealthMonitor.Services.Interfaces;

namespace ProjectHealthMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProjectRequest request)
        {
            var id = await _service.CreateProjectAsync(request);

            return Ok(new { ProjectId = id });
        }

        [HttpGet("{id}/health")]
        public async Task<IActionResult> GetHealth(Guid id)
        {
            var result = await _service.GetHealthAsync(id);

            return Ok(new ApiResponse<ProjectHealthResponse>
            {
                Success = true,
                Message = "Project health calculated successfully",
                Data = result,
                TraceId = HttpContext.TraceIdentifier
            });
        }
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("Project Health API Running");
        }
    }
}
