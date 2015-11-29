using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.Common.Controllers;
using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MunkaidoNyilvantarto.Controllers
{
    public class IssuesController : BaseController
    {

        public IIssueService IssueService { get; set; }

        public async Task<ActionResult> GetIssuesByProject(int id)
        {
            return Json(new ServiceResult
            {
                Data = new List<IssueListViewModel>
                {
                    new IssueListViewModel { Id = 1, Description = "descrip", Title = "javítani ezt meg ezt", State = Data.Entity.IssueState.Inprogress, TotalHours = 34.2 },
                    new IssueListViewModel { Id = 1, Description = "descrip", Title = "javítani ezt meg ezt", State = Data.Entity.IssueState.New, TotalHours = 34.2 },
                    new IssueListViewModel { Id = 1, Description = "descrip", Title = "javítani ezt meg ezt", State = Data.Entity.IssueState.Testing, TotalHours = 34.2 }
                }
            });
        }

        public async Task<ActionResult> GetIssueDetails(int id)
        {
            return Json(new ServiceResult
            {
                Data = new IssueDetailsViewModel
                {
                    Id = 1,
                    ProjectId = 2,
                    Title = "issue title",
                    Description = "issue description",
                    State = Data.Entity.IssueState.Ready,
                    Comments = new List<ViewModels.Comment.CommentListViewModel>
                    {
                        new ViewModels.Comment.CommentListViewModel { Id = 1, Title = "szép munka!", Body = "nagyon jól meglettek ezek", UserName = "Nagyonfelelős Norbert", Created = DateTime.Now }
                    },
                    SpentTimes = new List<ViewModels.SpentTime.SpentTimeListViewModel>
                    {
                        new ViewModels.SpentTime.SpentTimeListViewModel { Id = 1, UserName = "Dolgozó Dániel", Date = DateTime.Now, Hour = 6.5 }
                    }
                }
            });
        }

        public async Task<ActionResult> GetIssueEditViewModel(int id)
        {
            return Json(new ServiceResult
            {
                Data = new IssueEditViewModel
                {
                    Id = id,
                    ProjectId = 3
                }
            });
        }

        public async Task<ActionResult> CreateIssue(IssueEditViewModel model)
        {
            return Json(new ServiceResult
            {

            });
        }

        public async Task<ActionResult> ChangeState(int issueId, IssueState newState)
        {
            return Json(new ServiceResult
            {

            });
        }

        [Authorize]
        public async Task<ActionResult> GetIssuesByUser()
        {
            var result = await IssueService.GetIssuesByUser(HttpContext.User.Identity.GetUserId());

            return Json(new ServiceResult { Data = result });
        }
    }
}