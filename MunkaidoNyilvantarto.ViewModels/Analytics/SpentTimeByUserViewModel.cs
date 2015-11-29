using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Analytics
{
    public class SpentTimeIssueListViewModel
    {
        public string IssueTitle { get; set; }

        public double Hours { get; set; }
    }

    public class SpentTimeByIssueViewModel
    {
        public string ProjectName { get; set; }

        public List<SpentTimeIssueListViewModel> SpentTimes { get; set; }
    }
}
