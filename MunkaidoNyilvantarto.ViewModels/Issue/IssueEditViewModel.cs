using MunkaidoNyilvantarto.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Issue
{
    public class IssueEditViewModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// A projekt id-ja amihez tartozik
        /// </summary>
        [Required(ErrorMessage = "Kötelező a projektet megadni")]
        public int ProjectId { get; set; }

        /// <summary>
        /// A feladat leírása
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A feladat neve
        /// </summary>
        [Required(ErrorMessage = "Kötelező a címet megadni")]
        public string Title { get; set; }

        /// <summary>
        /// A feladat állapota
        /// </summary>
        [Required(ErrorMessage = "Kötelező az állapotot megadni")]
        public IssueState State { get; set; }
    }
}
