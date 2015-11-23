using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.Common.Controllers;
using MunkaidoNyilvantarto.ViewModels.Project;
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

        public async Task<ActionResult> GetProjectDetails(int id)
        {
            return Json(new ServiceResult
            {
                Data = new ProjectDetailsViewModel
                {
                    Id = 1,
                    Description = "projekt leírása",
                    Name = "első projekt"
                }
            });
        }
    }
}