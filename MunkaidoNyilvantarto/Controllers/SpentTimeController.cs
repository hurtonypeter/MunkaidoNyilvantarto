﻿using MunkaidoNyilvantarto.BLL;
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
                    new SpentTimeListViewModel { Id = 1, UserName = "Dolgozó Dániel", Date = DateTime.Now, Hour = 6.5 }
                }
            });
        }

        public async Task<ActionResult> Save(SpentTimeEditViewModel model)
        {
            return Json(new ServiceResult
            {

            });
        }
    }
}