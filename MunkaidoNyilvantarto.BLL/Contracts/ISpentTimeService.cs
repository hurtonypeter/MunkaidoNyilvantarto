using MunkaidoNyilvantarto.ViewModels.SpentTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    public interface ISpentTimeService
    {
        Task<IServiceResult> CreateSpentTime(SpentTimeEditViewModel model);

        Task<IServiceResult> UpdateSpentTime(SpentTimeEditViewModel model);

        Task<List<SpentTimeListViewModel>> GetSpentTimeByProject(int projectId);
    }
}
