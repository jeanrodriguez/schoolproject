using Entities.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_AngularJS.Models
{
    public class StudentViewModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Apartment { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }
}