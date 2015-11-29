using AutoMapper;
using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.ViewModels.Comment;
using MunkaidoNyilvantarto.ViewModels.Issue;
using MunkaidoNyilvantarto.ViewModels.Project;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
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

            //Project
            this.CreateMap<ProjectEditViewModel, Project>();
            this.CreateMap<Project, ProjectEditViewModel>()
                .ForMember(dst => dst.ResponsibleUserId, o => o.MapFrom(src => src.Responsible.Id));

            this.CreateMap<Project, ProjectListViewModel>();

            this.CreateMap<Project, ProjectDetailsViewModel>();

            //SpentTime
            this.CreateMap<SpentTimeEditViewModel, SpentTime>();
            this.CreateMap<SpentTime, SpentTimeEditViewModel>()
                .ForMember(dst => dst.IssueId, o => o.MapFrom(src => src.Issue.Id))
                .ForMember(dst => dst.UserId, o => o.MapFrom(src => src.User.Id));

            this.CreateMap<SpentTime, SpentTimeListViewModel>()
                .ForMember(dst => dst.UserName, o => o.MapFrom(src => src.User.UserName));

            this.CreateMap<SpentTime, SpentTimeDesktopListViewModel>()
                .ForMember(dst => dst.IssueName, o => o.MapFrom(src => src.Issue.Title))
                .ForMember(dst => dst.ProjectName, o => o.MapFrom(src => src.Issue.Project.Name));

        }
    }
}
