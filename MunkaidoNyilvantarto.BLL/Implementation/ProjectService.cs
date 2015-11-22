using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Project;
using AutoMapper;
using MunkaidoNyilvantarto.Data.Entity;
using System.Data.Entity;
using MunkaidoNyilvantarto.BLL.Identity;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class ProjectService : IProjectService
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// AutoMapper
        /// </summary>
        private readonly IMappingEngine mapper;

        /// <summary>
        /// felhasználók kezelésére
        /// </summary>
        private readonly ApplicationUserManager userManager;

        /// <summary>
        /// DI ctor
        /// </summary>
        public ProjectService(ApplicationDbContext context, IMappingEngine mapper, ApplicationUserManager userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IServiceResult> CreateProject(ProjectEditViewModel model)
        {
            var result = new ServiceResult<ProjectEditViewModel>();

            try
            {
                var responsible = await userManager.FindByIdAsync(model.ResponsibleUserId);
                if(responsible == null)
                {
                    result.AddError(m => m.ResponsibleUserId, "Ilyen felhasználó nem létezik");
                }

                if(result.Succeeded)
                {
                    var project = mapper.Map<Project>(model);
                    project.Responsible = responsible;

                    context.Projects.Add(project);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<ProjectEditViewModel> GetProjectEditViewModel(int id)
        {
            var project = await context.Projects
                .Include(p => p.Responsible)
                .FirstOrDefaultAsync(p => p.Id == id);

            return project == null ? null : mapper.Map<ProjectEditViewModel>(project);
        }

        public async Task<List<ProjectListViewModel>> ListProjects()
        {
            //return new List<ProjectListViewModel>
            //{
            //    new ProjectListViewModel { Id = 1, Name = "Projektnév 1", Description = "leírás 1" },
            //    new ProjectListViewModel { Id = 2, Name = "Projektnév 2", Description = "leírás 2" },
            //    new ProjectListViewModel { Id = 3, Name = "Projektnév 3", Description = "leírás 3" }
            //};

            return (await context.Projects
                .ToListAsync())
                .Select(p => mapper.Map<ProjectListViewModel>(p))
                .ToList();
        }

        public async Task<IServiceResult> UpdateProject(ProjectEditViewModel model)
        {
            var result = new ServiceResult<ProjectEditViewModel>();

            try
            {
                var project = model.Id.HasValue ? await context.Projects.Include(p => p.Responsible).FirstOrDefaultAsync(p => p.Id == model.Id.Value) : null;
                if(project == null)
                {
                    result.AddError("", "Ilyen projekt nem létezik");
                    return result;
                }
                
                var responsible = await userManager.FindByIdAsync(model.ResponsibleUserId);
                if (responsible == null)
                {
                    result.AddError(m => m.ResponsibleUserId, "Ilyen felhasználó nem létezik");
                }

                if (result.Succeeded)
                {
                    project.Deadline = model.Deadline;
                    project.Description = model.Description;
                    project.Name = model.Name;
                    project.Responsible = responsible;
                    
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }
    }
}
