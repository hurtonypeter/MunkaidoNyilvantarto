using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MunkaidoNyilvantarto.ViewModels.Comment
{
    public class CommentEditViewModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// Issue id-ja amihez kommentelünk
        /// </summary>
        [Required(ErrorMessage = "Kötelező a feladatot megadni")]
        public int IssueId { get; set; }

        /// <summary>
        /// A user id-ja aki felvette a commentet
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// leírás
        /// </summary>
        [Required(ErrorMessage = "Kötelező a leírást megadni")]
        public string Body { get; set; }

        /// <summary>
        /// Cím
        /// </summary>
        [Required(ErrorMessage = "Kötelező a címet megadni")]
        public string Title { get; set; }
    }
}
