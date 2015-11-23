using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.SpentTime
{
    public class SpentTimeEditViewModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// A feladat id-ja
        /// </summary>
        [Required]
        public int IssueId { get; set; }

        /// <summary>
        /// A felhasználó id-ja
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Melyik nap dolgozott
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Mennyit dolgozott
        /// </summary>
        [Required]
        public double Hour { get; set; }

        /// <summary>
        /// Megjegyzés
        /// </summary>
        public string Description { get; set; }
    }
}
