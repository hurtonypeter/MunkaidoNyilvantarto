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

        Task<IServiceResult> DeleteSpentTime(int id);

        Task<List<SpentTimeListViewModel>> GetSpentTimesByIssue(int issueId);

        Task<SpentTimeEditViewModel> GetSpentTiimeViewModel(int id);

        Task<List<SpentTimeDesktopListViewModel>> GetActualMonthSpentTimesByUser(string userId);
    }
}
