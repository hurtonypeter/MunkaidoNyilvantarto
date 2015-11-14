using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public class SpentTime
    {
        public int Id { get; set; }

        /// <summary>
        /// A munkaidőhöz tartozó felhasználó
        /// </summary>
        [Required]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// A munkaidőhöz tartozó feladat
        /// </summary>
        [Required]
        public virtual Issue Issue { get; set; }

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
