using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Issue;
using MunkaidoNyilvantarto.Data.Entity;
using AutoMapper;
using System.Data.Entity;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class IssueService : IIssueService
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
        /// DI ctor
        /// </summary>
        public IssueService(ApplicationDbContext context, IMappingEngine mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IServiceResult> CreateIssue(IssueEditViewModel model)
        {
            var result = new ServiceResult<IssueEditViewModel>();

            try
            {
                var project = await context.Projects.FindAsync(model.ProjectId);
                if(project == null)
                {
                    result.AddError(m => m.ProjectId, "Ilyen projekt nem létezik");
                    return result;
                }

                var issue = mapper.Map<Issue>(model);
                issue.Project = project;
                issue.State = IssueState.New;
                context.Issues.Add(issue);

                await context.SaveChangesAsync(); 

            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<List<IssueListViewModel>> GetIssuesByProject(int projectId)
        {
            return await context.Issues
                .Where(i => i.Project.Id == projectId)
                .Select(i => mapper.Map<IssueListViewModel>(i))
                .ToListAsync();
        }

        public Task<IServiceResult> UpdateIssue(IssueEditViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
