using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<SpentTime> SpentTimes { get; set; }

        /// <summary>
        /// Azok a projektek ahol a felhasználó  felelős
        /// </summary>
        [InverseProperty("Responsible")]
        public virtual ICollection<Project> ResponsibleProjects { get; set; }

        /// <summary>
        /// Azok a projektek ahol a felhasználó dolgozó
        /// </summary>
        [InverseProperty("Workers")]
        public virtual ICollection<Project> WorkerProjects { get; set; }

    }
}
