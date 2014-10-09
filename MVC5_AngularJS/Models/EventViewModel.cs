using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Models.Base;

namespace MVC5_AngularJS.Models
{
    public class EventViewModel : BaseEntity
    {
        public string Name { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Authors { get; set; }
    }
}