using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.Common.Controllers;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MunkaidoNyilvantarto.Controllers
{
    public class SpentTimeController : BaseController
    {
        public ISpentTimeService SpentTimeService { get; set; }

        public async Task<ActionResult> GetSpentTimeEditViewModel(int id)
        {
            return Json(new ServiceResult
            {
                Data = new SpentTimeEditViewModel
                {
                    Id = 1,
                    IssueId = 3,
                    UserId = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    Hour = 8.0,
                    Description = "nagyon dolgoztam a formon"
                }
            });
        }

        public async Task<ActionResult> GetSpentTimesByIssue(int id)
        {
            return Json(new ServiceResult
            {
                Data = new List<SpentTimeListViewModel>
                {
                    new SpentTimeListViewModel { Id = 1, UserName = "Dolgozó Dániel", Date = DateTime.Now, Hour = 6.5 },
                    new SpentTimeListViewModel { Id = 1, UserName = "Dolgozó Dániel 2", Date = DateTime.Now, Hour = 2.5 },
                    new SpentTimeListViewModel { Id = 1, UserName = "Dolgozó Dániel 2", Date = DateTime.Now, Hour = 3.5 }
                }
            });
        }

        public async Task<ActionResult> Save(SpentTimeEditViewModel model)
        {
            return Json(new ServiceResult
            {

            });
        }

        [Authorize]
        public async Task<ActionResult> GetActualMonthSpentTimesByUser()
        {
            var spentTimes = await SpentTimeService.GetActualMonthSpentTimesByUser(HttpContext.User.Identity.GetUserId());

            return Json(new ServiceResult { Data = spentTimes });
        }

        public async Task<ActionResult> Create(SpentTimeEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var ret = new ServiceResult();
                AddModelErrorsToResult(ret);
                return Json(ret);    
            }

            model.UserId = HttpContext.User.Identity.GetUserId();
            var result = await SpentTimeService.CreateSpentTime(model);

            return Json(result);
        }
    }
}