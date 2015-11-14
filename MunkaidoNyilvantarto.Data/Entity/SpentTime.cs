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
        public virtual Task Task { get; set; }
    }
}
