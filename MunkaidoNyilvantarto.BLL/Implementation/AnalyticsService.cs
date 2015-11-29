using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Analytics;
using MunkaidoNyilvantarto.Data.Entity;
using System.Data.Entity;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationDbContext context;

        public AnalyticsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<SpentTimeByProjectViewModel>> GetAllSpentTimeByProject()
        {
            var ret = await context.SpentTimes
                 .GroupBy(s => new
                 {
                     Id = s.Issue.Project.Id,
                     Name = s.Issue.Project.Name
                 })
                 .Select(sg => new SpentTimeByProjectViewModel
                 {
                     ProjectName = sg.Key.Name,
                     Hours = sg.Sum(s => s.Hour)
                 })
                 .ToListAsync();

            return ret;
        }

        public async Task<SpentTimeByIssueViewModel> GetProjectSpentsTimesByIssue(int projectId)
        {
            var project = await context.Projects.FindAsync(projectId);
            if(project == null)
            {
                return null;
            }

            var spentTimes = await context.SpentTimes
                .Where(s => s.Issue.Project.Id == projectId)
                .GroupBy(s => new
                {
                    UserId = s.User.Id,
                    IssueTitle = s.Issue.Title
                })
                .Select(sg => new SpentTimeIssueListViewModel
                {
                    IssueTitle = sg.Key.IssueTitle,
                    Hours = sg.Sum(s => s.Hour)
                })
                .ToListAsync();

            var ret = new SpentTimeByIssueViewModel { ProjectName = project.Name, SpentTimes = spentTimes };

            return ret;
        }
    }
}
