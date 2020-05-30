using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Data.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
    }
}
