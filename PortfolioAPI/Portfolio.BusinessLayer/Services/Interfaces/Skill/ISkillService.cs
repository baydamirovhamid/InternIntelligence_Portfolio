using Portfolio.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Interfaces.Skill
{
    public interface ISkillService
    {
        Task<bool> CreateAsync(SkillDto skillDto);
        Task<bool> UpdateAsync(Guid id, SkillDto skillDto);
        Task<bool> DeleteAsync(Guid id);
        Task<SkillDto> GetByIdAsync(Guid id);
        Task<List<SkillDto>> GetAllAsync();
    }
}
