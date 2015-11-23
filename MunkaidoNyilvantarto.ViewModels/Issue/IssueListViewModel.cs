using MunkaidoNyilvantarto.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Issue
{
    public class IssueListViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// A feladat leírása
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A feladat neve
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A feladat állapota
        /// </summary>
        public IssueState State { get; set; }

        /// <summary>
        /// A feladatra eddig összesen beregisztrált idő órában
        /// </summary>
        public double TotalHours { get; set; }
    }
}
