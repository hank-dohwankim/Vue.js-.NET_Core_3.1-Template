using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Data.Models;

namespace Template.Web.ViewModels
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
