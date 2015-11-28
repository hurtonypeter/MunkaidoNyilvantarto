using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public class Comment
    {
        public int Id { get; set; }

        /// <summary>
        /// A kommenthez tartozó fealdat
        /// </summary>
        [Required]
        public virtual Issue Issue { get; set; }

        /// <summary>
        /// A Comment címe
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// A komment
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// komment írásának ideje
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// A felhasználó aki kommentelt
        /// </summary>
        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
