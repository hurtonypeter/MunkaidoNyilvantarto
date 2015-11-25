using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.SpentTime
{
    public class SpentTimeDesktopListViewModel
    {
        public string ProjectName { get; set; }

        public string IssueName { get; set; }

        public DateTime Date { get; set; }

        public double Hour { get; set; }
    }
}
