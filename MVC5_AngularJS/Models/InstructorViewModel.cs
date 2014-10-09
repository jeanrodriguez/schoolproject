using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Models.Base;

namespace MVC5_AngularJS.Models
{
    public class InstructorViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
    }
}