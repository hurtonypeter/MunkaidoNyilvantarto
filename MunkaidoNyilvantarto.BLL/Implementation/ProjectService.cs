using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Project;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class ProjectService : IProjectService
    {
        public Task<IServiceResult> CreateProject(ProjectEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectListViewModel>> ListProjects()
        {
            return new List<ProjectListViewModel>
            {
                new ProjectListViewModel { Id = 1, Name = "Projektnév 1", Description = "leírás 1" },
                new ProjectListViewModel { Id = 2, Name = "Projektnév 2", Description = "leírás 2" },
                new ProjectListViewModel { Id = 3, Name = "Projektnév 3", Description = "leírás 3" }
            };
        }

        public Task<IServiceResult> UpdateProject(ProjectEditViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
