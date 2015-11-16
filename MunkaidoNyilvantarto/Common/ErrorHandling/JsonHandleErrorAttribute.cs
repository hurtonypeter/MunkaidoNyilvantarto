using MunkaidoNyilvantarto.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MunkaidoNyilvantarto.Common.ErrorHandling
{
    /// <summary>
    /// MVC-s handleerrorattribute, azért felel, hogy ha json-t kértünk, 
    /// akkor mindenképpen json válasz érkezzen, mvc-s hibák esetén is, 
    /// amikor nem a kontroller action válaszol.
    /// </summary>
    public class JsonHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentType == "application/json")
            {
                var data = new ServiceResult();
                data.AddError("", "Hiba történt a kérés során");

                filterContext.Result = new JsonResult()
                {
                    Data = data,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}