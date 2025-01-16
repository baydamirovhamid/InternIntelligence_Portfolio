using Portfolio.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Interfaces.Achievement
{
    public interface IAchievementService
    {
        Task<bool> CreateAsync(AchievementDto achievementDto);
        Task<bool> UpdateAsync(Guid id, AchievementDto achievementDto);
        Task<bool> DeleteAsync(Guid id);
        Task<AchievementDto> GetByIdAsync(Guid id);
        Task<List<AchievementDto>> GetAllAsync();
    }
}
