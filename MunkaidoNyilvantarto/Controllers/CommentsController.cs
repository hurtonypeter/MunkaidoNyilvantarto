using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.Common.Controllers;
using MunkaidoNyilvantarto.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MunkaidoNyilvantarto.Controllers
{
    public class CommentsController : BaseController
    {

        public async Task<ActionResult> Create(CommentEditViewModel model)
        {
            return Json(new ServiceResult
            {
                Data = new CommentListViewModel { Id = 3, Title = model.Title, Body = model.Body, UserName = "Oké Olivér", Created = DateTime.Now }
            });
        }

        
    }
}