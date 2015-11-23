using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.Common.Controllers;
using MunkaidoNyilvantarto.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
    }
}