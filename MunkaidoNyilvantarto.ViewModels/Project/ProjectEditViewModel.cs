using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Project
{
    public class ProjectEditViewModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// A felelős személy id-ja
        /// </summary>
        [Required(ErrorMessage = "Kötelező felelőst megadni")]
        public string ResponsibleUserId { get; set; }

        /// <summary>
        /// A projekt neve
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Projekt leírása
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// A projekt lejárati ideje
        /// </summary>
        [Required]
        public DateTime Deadline { get; set; }
    }
}
