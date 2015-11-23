using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
using MunkaidoNyilvantarto.Data.Entity;
using AutoMapper;
using MunkaidoNyilvantarto.BLL.Identity;
using System.Data.Entity;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    class SpentTimeService : ISpentTimeService
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
        public SpentTimeService(ApplicationDbContext context, IMappingEngine mapper, ApplicationUserManager userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IServiceResult> CreateSpentTime(SpentTimeEditViewModel model)
        {
            var result = new ServiceResult<SpentTimeEditViewModel>();

            try
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if(user == null)
                {
                    result.AddError("", "Ez a felhasználó nem létezik");
                }

                var issue = await context.Issues.FindAsync(model.IssueId);
                if(issue == null)
                {
                    result.AddError(m => m.IssueId, "Ez a feladat nem létezik");
                }

                if(result.Succeeded)
                {
                    var spentTime = mapper.Map<SpentTime>(model);
                    spentTime.User = user;
                    spentTime.Issue = issue;

                    context.SpentTimes.Add(spentTime);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<IServiceResult> DeleteSpentTime(int id)
        {
            var result = new ServiceResult<SpentTimeEditViewModel>();

            try
            {
                var spentTime = await context.SpentTimes.FindAsync(id);
                if(spentTime == null)
                {
                    result.AddError("", "Ez a munkaidő nem létezik");
                    return result;
                }

                context.SpentTimes.Remove(spentTime);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<SpentTimeEditViewModel> GetSpentTiimeViewModel(int id)
        {
            var spentTime = await context.SpentTimes
                .Include(s => s.User)
                .Include(s => s.Issue)
                .FirstOrDefaultAsync(s => s.Issue.Id == id);
            return spentTime == null ? null : mapper.Map<SpentTimeEditViewModel>(spentTime);
        }

        public async Task<List<SpentTimeListViewModel>> GetSpentTimesByIssue(int issueId)
        {
            return (await context.SpentTimes
                .Where(s => s.Issue.Id == issueId)
                .ToListAsync())
                .Select(s => mapper.Map<SpentTimeListViewModel>(s))
                .ToList();
        }

        public async Task<IServiceResult> UpdateSpentTime(SpentTimeEditViewModel model)
        {
            var result = new ServiceResult<SpentTimeEditViewModel>();

            try
            {
                var spentTime = model.Id.HasValue ?
                    await context.SpentTimes
                        .Include(s => s.Issue)
                        .Include(s => s.User)
                        .FirstOrDefaultAsync(s => s.Id == model.Id.Value) :
                    null;

                if(spentTime == null)
                {
                    result.AddError("", "Nem létezik a munkaidő");
                }

                if (model.UserId != spentTime.User.Id)
                {
                    result.AddError("", "Csak az módosíthatja a munkaidőt aki felvette");
                } 

                var issue = await context.Issues.FindAsync(model.IssueId);
                if (issue == null)
                {
                    result.AddError(m => m.IssueId, "Ez a feladat nem létezik");
                }

                if (result.Succeeded)
                {
                    spentTime.Date = model.Date;
                    spentTime.Description = model.Description;
                    spentTime.Hour = model.Hour;
                    spentTime.Issue = issue;
                    
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
