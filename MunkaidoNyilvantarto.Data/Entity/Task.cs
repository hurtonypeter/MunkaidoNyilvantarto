using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public class Task
    {
        public int Id { get; set; }

        /// <summary>
        /// A feladatra eltöltött munkaidők
        /// </summary>
        public virtual ICollection<SpentTime> SpentTimes { get; set; }

        /// <summary>
        /// A feladathoz tartozó projekt
        /// </summary>
        [Required]
        public virtual Project Project { get; set; }

        /// <summary>
        /// A feladathoz tartozó kommentek
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
