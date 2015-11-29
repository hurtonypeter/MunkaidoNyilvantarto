using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MunkaidoNyilvantarto.Common.Controllers
{
    public class BaseController : Controller
    {
        protected internal new JsonResult Json(Object data)
        {
            return new JsonNetResult() { Data = data };
        }

        protected internal new JsonResult Json(Object data, string contentType)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType };
        }

        protected internal new JsonResult Json(Object data, JsonRequestBehavior behavior)
        {
            return new JsonNetResult() { Data = data, JsonRequestBehavior = behavior };
        }

        protected internal new JsonResult Json(Object data, string contentType, Encoding contentEncoding)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }

        protected internal new JsonResult Json(Object data, string contentType, JsonRequestBehavior behavior)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType, JsonRequestBehavior = behavior };
        }

        protected internal new JsonResult Json(Object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }

        protected void AddModelErrorsToResult(IServiceResult result)
        {
            foreach (var item in ModelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    result.AddError(item.Key, error.ErrorMessage);
                }
            }
        }
    }
}