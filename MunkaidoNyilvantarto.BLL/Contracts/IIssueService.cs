using MunkaidoNyilvantarto.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    public interface IIssueService
    {
        Task<IServiceResult> CreateIssue(IssueEditViewModel model);

        Task<IServiceResult> UpdateIssue(IssueEditViewModel model);
        
        Task<List<IssueListViewModel>> GetIssuesByProject(int projectId);

        Task<IssueEditViewModel> GetIssueEditViewModel(int id);

        Task<List<IssueListViewModel>> GetIssuesByUser(string userId);
    }
}
