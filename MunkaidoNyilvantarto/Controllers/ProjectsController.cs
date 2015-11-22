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
    public class ProjectsController : BaseController
    {
        public IProjectService ProjectService { get; set; }

        // GET: Projects
        public async Task<ActionResult> ListProjects()
        {
            return Json(new ServiceResult { Data = await ProjectService.ListProjects() });
        }
    }
}