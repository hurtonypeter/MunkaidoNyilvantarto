using Microsoft.AspNet.Identity;
using MunkaidoNyilvantarto.BLL;
using MunkaidoNyilvantarto.BLL.Contracts;
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
        public ICommentService CommentService { get; set; }

        public async Task<ActionResult> Create(CommentEditViewModel model)
        {
            model.UserId = HttpContext.User.Identity.GetUserId();
            return Json(await CommentService.CreateComment(model));
        }

        
    }
}