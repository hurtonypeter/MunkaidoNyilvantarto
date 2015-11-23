using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.SpentTime
{
    public class SpentTimeListViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// Melyik nap dolgozott
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Mennyit dolgozott
        /// </summary>
        public double Hour { get; set; }
    }
}
