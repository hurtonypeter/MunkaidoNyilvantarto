using MunkaidoNyilvantarto.Data.Entity;
using MunkaidoNyilvantarto.ViewModels.Comment;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Issue
{
    public class IssueDetailsViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        /// <summary>
        /// A feladat leírása
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A feladat neve
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A feladat állapota
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public IssueState State { get; set; }

        public List<CommentListViewModel> Comments { get; set; }

        public List<SpentTimeListViewModel> SpentTimes { get; set; }
    }
}
