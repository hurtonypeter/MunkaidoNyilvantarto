using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.ViewModels.Comment
{
    public class CommentListViewModel
    {
        /// <summary>
        /// Kommenet Id-ja
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A leírás
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Cím
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A felhasználó neve aki a kommentet írta
        /// </summary>
        public string UserName { get; set; }
    }
}
