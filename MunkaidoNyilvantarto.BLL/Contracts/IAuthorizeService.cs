using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    public interface IAuthorizeService
    {
        /// <summary>
        /// Megmondja hogy a user hozzáférhet-e az adott projekthez
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        bool HavePermissoinToProject(string userId, int projectId);
    }
}
