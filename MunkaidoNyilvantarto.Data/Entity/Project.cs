using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public class Project
    {
        public int Id { get; set; }

        /// <summary>
        /// A projektért felelős személy
        /// </summary>
        [Required]
        public virtual ApplicationUser Responsible { get; set; }

        /// <summary>
        /// A projekten dologozó munkások
        /// </summary>
        public virtual ICollection<ApplicationUser> Workers { get; set; }

        /// <summary>
        /// A projekthez tartozó feladatok
        /// </summary>
        public virtual ICollection<Issue> Issues { get; set; }

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
