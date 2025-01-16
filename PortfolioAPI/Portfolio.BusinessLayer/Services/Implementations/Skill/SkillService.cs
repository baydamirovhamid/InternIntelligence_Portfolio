using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Skill;
using Portfolio.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Implementations.Skill
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Domain.Entities.Skill> _repository;

        public SkillService(IRepository<Domain.Entities.Skill> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(SkillDto skillDto)
        {
            var skill = new Domain.Entities.Skill
            {
                Name = skillDto.Name
            };
            return await _repository.AddAsync(skill);
        }

        public async Task<bool> UpdateAsync(Guid id, SkillDto skillDto)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return false;

            skill.Name = skillDto.Name;
            return await _repository.UpdateAsync(skill);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return false;

            return await _repository.RemoveAsync(skill);
        }

        public async Task<SkillDto> GetByIdAsync(Guid id)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return null;

            return new SkillDto
            {
                Name = skill.Name
            };
        }

        public async Task<List<SkillDto>> GetAllAsync()
        {
            var skills = await _repository.GetAllAsync();
            var skillDtos = new List<SkillDto>();

            foreach (var skill in skills)
            {
                skillDtos.Add(new SkillDto
                {
                    Name = skill.Name
                });
            }

            return skillDtos;
        }
    }
}
