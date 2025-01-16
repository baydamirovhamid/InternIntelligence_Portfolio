using Portfolio.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Interfaces.Project
{
    public interface IProjectService
    {
        Task<bool> CreateAsync(ProjectDto projectDto);
        Task<bool> UpdateAsync(Guid id, ProjectDto projectDto);
        Task<bool> DeleteAsync(Guid id);
        Task<ProjectDto> GetByIdAsync(Guid id);
        Task<List<ProjectDto>> GetAllAsync();
    }
}
