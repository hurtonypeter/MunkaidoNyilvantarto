using MunkaidoNyilvantarto.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL.Contracts
{
    public interface ICommentService
    {
        Task<IServiceResult> CreateComment(CommentEditViewModel model);

        Task<IServiceResult> UpdateComment(CommentEditViewModel model);
                
        Task<List<CommentListViewModel>> GetCommentsByIssue(int issueId);
    }
}
