using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Comment;
using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.BLL.Identity;
using AutoMapper;
using System.Data.Entity;


namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class CommentService : ICommentService
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// felhasználók kezelésére
        /// </summary>
        private readonly ApplicationUserManager userManager;

        /// <summary>
        /// AutoMapper
        /// </summary>
        private readonly IMappingEngine mapper;

        /// <summary>
        /// DI ctor
        /// </summary>
        public CommentService(ApplicationDbContext context, ApplicationUserManager userManager, IMappingEngine mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IServiceResult> CreateComment(CommentEditViewModel model)
        {
            var result = new ServiceResult<CommentEditViewModel>();

            try
            {
                var issue = await context.Issues.FindAsync(model.IssueId);
                if (issue == null)
                {
                    result.AddError(m => m.IssueId, "Ez a feladat nem létezik");
                }

                var user = await userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    result.AddError(m => m.UserId, "Ez a felhasználó nem létezik");
                }

                if (result.Succeeded)
                {
                    var comment = mapper.Map<Comment>(model);
                    comment.User = user;
                    comment.Issue = issue;

                    context.Comments.Add(comment);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<List<CommentListViewModel>> GetCommentsByIssue(int issueId)
        {
            return (await context.Comments
                .Include(c => c.User)
                .Where(c => c.Issue.Id == issueId)
                .ToListAsync())
                .Select(c => mapper.Map<CommentListViewModel>(c))
                .ToList();
        }

        public async Task<IServiceResult> UpdateComment(CommentEditViewModel model)
        {
            var result = new ServiceResult<CommentEditViewModel>();

            try
            {
                var comment = model.Id.HasValue ?  await context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == model.Id.Value) : null;
                if(comment == null)
                {
                    result.AddError("", "Ez a komment nem létezik");
                    return result;
                }

                if(comment.User.Id != model.UserId)
                {
                    result.AddError(m => m.UserId, "Csak az szerkesztheti a kommentet aki létrehozta");
                }

                if (result.Succeeded)
                {
                    comment.Body = model.Body;
                    comment.Title = model.Title;

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                result.AddError("", e.Message);
            }

            return result;
        }

        public async Task<CommentEditViewModel> GetCommentEditViewModel(int id)
        {
            var comment = await context.Comments
                .Include(c => c.Issue)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            return comment == null ? null : mapper.Map<CommentEditViewModel>(comment);
        }
    }
}
