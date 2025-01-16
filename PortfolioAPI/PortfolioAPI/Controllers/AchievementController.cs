using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Achievement;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var achievements = await _achievementService.GetAllAsync();
            if (achievements == null || achievements.Count == 0)
            {
                return NoContent(); 
            }

            return Ok(achievements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var achievement = await _achievementService.GetByIdAsync(id);
            if (achievement == null)
            {
                return NotFound("Achievement not found."); 
            }

            return Ok(achievement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AchievementDto achievementDto)
        {
            if (achievementDto == null)
            {
                return BadRequest("Achievement data is null."); 
            }

            var isCreated = await _achievementService.CreateAsync(achievementDto);
      
            return BadRequest("Success to create achievement."); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AchievementDto achievementDto)
        {
            if (achievementDto == null)
            {
                return BadRequest("Achievement data is null.");
            }

            var isUpdated = await _achievementService.UpdateAsync(id, achievementDto);
            if (isUpdated)
            {
                return Ok("Achievement updated successfully.");
            }

            return NotFound("Achievement not found."); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _achievementService.DeleteAsync(id);
            if (isDeleted)
            {
                return Ok("Achievement deleted successfully.");
            }

            return NotFound("Achievement not found."); 
        }
    }
}
