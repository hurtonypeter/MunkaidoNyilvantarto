using MunkaidoNyilvantarto.ViewModels.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    /// <summary>
    /// analítikák üzleti logikája, minden egyes 
    /// analítikához tartozni fog egy függvény és egy viewmodel
    /// </summary>
    public interface IAnalyticsService
    {
        Task<List<SpentTimeByProjectViewModel>> GetAllSpentTimeByProject();

        Task<SpentTimeByIssueViewModel> GetProjectSpentsTimesByIssue(int projectId);
    }
}
