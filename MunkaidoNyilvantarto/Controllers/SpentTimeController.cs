using Microsoft.AspNet.Identity;
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

namespace MunkaidoNyilvantarto.Controllers
{
    public class SpentTimeController : BaseController
    {
        public ISpentTimeService SpentTimeService { get; set; }

        public async Task<ActionResult> GetSpentTimeEditViewModel(int id)
        {
            var model = await SpentTimeService.GetSpentTiimeViewModel(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return Json(new ServiceResult
            {
                Data = model
            });
        }

        public async Task<ActionResult> GetSpentTimesByIssue(int id)
        {
            return Json(new ServiceResult
            {
                Data = await SpentTimeService.GetSpentTimesByIssue(id)
            });
        }

        public async Task<ActionResult> Save(SpentTimeEditViewModel model)
        {
            if (model.Id.HasValue)
            {
                return Json(await SpentTimeService.UpdateSpentTime(model));
            }
            else
            {
                model.UserId = HttpContext.User.Identity.GetUserId();
                return Json(await SpentTimeService.CreateSpentTime(model));
            }
        }
    }
}