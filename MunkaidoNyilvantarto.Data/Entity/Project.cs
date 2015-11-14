﻿using System;
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
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
