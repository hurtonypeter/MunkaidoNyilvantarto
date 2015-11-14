using Microsoft.AspNet.Identity.EntityFramework;
using MunkaidoNyilvantarto.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Repository
{
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}
