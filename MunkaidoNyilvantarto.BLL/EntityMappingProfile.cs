using AutoMapper;
using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.ViewModels.Comment;
using MunkaidoNyilvantarto.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.BLL
{
    public class EntityMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            //Comment
            this.CreateMap<CommentEditViewModel, Comment>();
            this.CreateMap<Comment, CommentEditViewModel>()
                .ForMember(dst => dst.IssueId, o => o.MapFrom(src => src.Issue.Id))
                .ForMember(dst => dst.UserId, o => o.MapFrom(src => src.User.Id));
            
            this.CreateMap<Comment, CommentListViewModel>()
                .ForMember(dst => dst.UserName, o => o.MapFrom(src => src.User.UserName));

            //Isssue
            this.CreateMap<IssueEditViewModel, Issue>();
            this.CreateMap<Issue, IssueEditViewModel>()
                .ForMember(dst => dst.ProjectId, o => o.MapFrom(src => src.Project.Id));

            this.CreateMap<Issue, IssueListViewModel>();
            
        }
    }
}
