using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Data.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2)]
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
