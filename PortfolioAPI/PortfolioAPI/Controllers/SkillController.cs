using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Skill;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var skills = await _skillService.GetAllAsync();
            if (skills == null || skills.Count == 0)
            {
                return NoContent(); 
            }

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);
            if (skill == null)
            {
                return NotFound("Skill not found."); 
            }

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SkillDto skillDto)
        {
            if (skillDto == null || string.IsNullOrEmpty(skillDto.Name))
            {
                return BadRequest("Skill data or name is null.");
            }

            var isCreated = await _skillService.CreateAsync(skillDto);
          
            return BadRequest("Success to create skill.");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] SkillDto skillDto)
        {
            if (skillDto == null)
            {
                return BadRequest("Skill data is null.");
            }

            var isUpdated = await _skillService.UpdateAsync(id, skillDto);
            if (isUpdated)
            {
                return Ok("Skill updated successfully.");
            }

            return NotFound("Skill not found."); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _skillService.DeleteAsync(id);
            if (isDeleted)
            {
                return Ok("Skill deleted successfully.");
            }

            return NotFound("Skill not found."); 
        }
    }
}
