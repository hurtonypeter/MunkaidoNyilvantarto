using MunkaidoNyilvantarto.BLL.Contracts;
using MunkaidoNyilvantarto.BLL.Identity;
using MunkaidoNyilvantarto.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MunkaidoNyilvantarto.BLL.Implementation
{
    public class AuthorizeService : IAuthorizeService
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// felhasználók kezelésére
        /// </summary>
        private readonly ApplicationUserManager userManager;

        /// <summary>
        /// DI ctor
        /// </summary>
        public AuthorizeService(ApplicationDbContext context, ApplicationUserManager userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public bool HavePermissoinToProject(string userId, int projectId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                return false;
            }

            if(userManager.IsInRole(userId, RoleType.Manager.ToString()))
            {
                return true;
            }

            var project = context.Projects.Find(projectId);
            if(project == null)
            {
                return false;
            }

            return project.Workers.Any(w => w.Id == userId);
        }
    }
}
