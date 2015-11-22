using MunkaidoNyilvantarto.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MunkaidoNyilvantarto.Common
{
    public class ProjectAuthorizeAttribute : AuthorizeAttribute
    {
        public IAuthorizeService authorizeService { get; set; }

        /// <summary>
        /// Ezen a néven kell kereseni a projectId értékét a formban
        /// </summary>
        public string ProjectIdKey { get; private set; }

        public ProjectAuthorizeAttribute(string projectIdKey)
            : base()
        {
            this.ProjectIdKey = projectIdKey;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userId = httpContext.User.Identity.GetUserId();
            int projectId;

            if(Int32.TryParse(httpContext.Request.Form[ProjectIdKey], out projectId))
            {
                return authorizeService.HavePermissoinToProject(userId, projectId);
            }
            else
            {
                return false;
            }
        }
    }
}