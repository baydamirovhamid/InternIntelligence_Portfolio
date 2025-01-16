using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Project;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var projects = await _projectService.GetAllAsync();
            if (projects == null || projects.Count == 0)
            {
                return NoContent(); 
            }

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project not found."); 
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProjectDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Project data is null."); 
            }

            var isCreated = await _projectService.CreateAsync(projectDto);
        

            return BadRequest("Success to create project."); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ProjectDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Project data is null.");
            }

            var isUpdated = await _projectService.UpdateAsync(id, projectDto);
            if (isUpdated)
            {
                return Ok("Project updated successfully.");
            }

            return NotFound("Project not found."); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _projectService.DeleteAsync(id);
            if (isDeleted)
            {
                return Ok("Project deleted successfully.");
            }

            return NotFound("Project not found."); 
        }
    }
}
