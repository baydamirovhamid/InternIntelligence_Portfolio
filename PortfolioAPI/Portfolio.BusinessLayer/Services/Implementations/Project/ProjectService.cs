using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.Project;
using Portfolio.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Implementations.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Domain.Entities.Project> _repository;

        public ProjectService(IRepository<Domain.Entities.Project> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(ProjectDto projectDto)
        {
            var project = new Domain.Entities.Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description
            };
            return await _repository.AddAsync(project);
        }

        public async Task<bool> UpdateAsync(Guid id, ProjectDto projectDto)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return false;

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;

            return await _repository.UpdateAsync(project);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return false;

            return await _repository.RemoveAsync(project);
        }

        public async Task<ProjectDto> GetByIdAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return null;

            return new ProjectDto
            {
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projects = await _repository.GetAllAsync();
            var projectDtos = new List<ProjectDto>();

            foreach (var project in projects)
            {
                projectDtos.Add(new ProjectDto
                {
                    Name = project.Name,
                    Description = project.Description
                });
            }

            return projectDtos;
        }
    }
}
