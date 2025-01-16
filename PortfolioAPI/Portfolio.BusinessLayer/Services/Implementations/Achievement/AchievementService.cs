using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Achievement;
using Portfolio.DataAccessLayer.Repositories;

namespace Portfolio.BusinessLayer.Services.Implementations.Achievement
{
    public class AchievementService : IAchievementService
    {
        private readonly IRepository<Domain.Entities.Achievement> _repository;

        public AchievementService(IRepository<Domain.Entities.Achievement> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(AchievementDto achievementDto)
        {
            var achievement = new Domain.Entities.Achievement
            {
                Title = achievementDto.Title,
                Description = achievementDto.Description,
            };
            return await _repository.AddAsync(achievement);
        }

        public async Task<bool> UpdateAsync(Guid id, AchievementDto achievementDto)
        {
            var achievement = await _repository.GetByIdAsync(id);
            if (achievement == null)
                return false;

            achievement.Title = achievementDto.Title;
            achievement.Description = achievementDto.Description;

            return await _repository.UpdateAsync(achievement);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var achievement = await _repository.GetByIdAsync(id);
            if (achievement == null)
                return false;

            return await _repository.RemoveAsync(achievement);
        }

        public async Task<AchievementDto> GetByIdAsync(Guid id)
        {
            var achievement = await _repository.GetByIdAsync(id);
            if (achievement == null)
                return null;

            return new AchievementDto
            {
                Title = achievement.Title,
                Description = achievement.Description,
            };
        }

        public async Task<List<AchievementDto>> GetAllAsync()
        {
            var achievements = await _repository.GetAllAsync();
            var achievementDtos = new List<AchievementDto>();

            foreach (var achievement in achievements)
            {
                achievementDtos.Add(new AchievementDto
                {
                    Title = achievement.Title,
                    Description = achievement.Description,
                });
            }

            return achievementDtos;
        }
    }
}
