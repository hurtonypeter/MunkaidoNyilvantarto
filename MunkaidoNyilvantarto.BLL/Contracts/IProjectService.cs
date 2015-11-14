using MunkaidoNyilvantarto.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    public interface IProjectService
    {
        Task<IServiceResult> CreateProject(ProjectEditViewModel model);

        Task<IServiceResult> UpdateProject(ProjectEditViewModel model);

        Task<List<ProjectListViewModel>> ListProjects();
    }
}
