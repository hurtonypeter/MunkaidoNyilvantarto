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
                Data = await IssueService.GetIssuesByProject(id)
            });
        }

        public async Task<ActionResult> GetIssueDetails(int id)
        {
            var model = await IssueService.GetIssueDetails(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return Json(new ServiceResult
            {
                Data = model
            });
        }

        public async Task<ActionResult> GetIssueEditViewModel(int id)
        {
            var model = await IssueService.GetIssueEditViewModel(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return Json(new ServiceResult
            {
                Data = model
            });
        }

        public async Task<ActionResult> CreateIssue(IssueEditViewModel model)
        {
            return Json(await IssueService.CreateIssue(model));
        }

        public async Task<ActionResult> ChangeState(int issueId, IssueState newState)
        {
            return Json(await IssueService.ChangeState(issueId, newState));
        }

        [Authorize]
        public async Task<ActionResult> GetIssuesByUser()
        {
            var result = await IssueService.GetIssuesByUser(HttpContext.User.Identity.GetUserId());

            return Json(new ServiceResult { Data = result });
        }
    }
}