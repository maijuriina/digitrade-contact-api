using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactWebApi.Models
{
    public partial class Contact
    {
        public long Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Street { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
    }
}