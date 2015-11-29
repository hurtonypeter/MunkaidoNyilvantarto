using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MunkaidoNyilvantarto.Controllers
{
    public class AnalyticsController : BaseController
    {
        public IAnalyticsService AnalyticsService { get; set; }

        public async Task<ActionResult> GeGetAllSpentTimeByProjecttP()
        {
            return Json(new ServiceResult { Data = await AnalyticsService.GetAllSpentTimeByProject() });
        }

        public async Task<ActionResult> GetProjectSpentTimeByIssue(int projectId)
        {
            return Json(new ServiceResult { Data = await AnalyticsService.GetProjectSpentsTimesByIssue(projectId) });
        }
    }
}