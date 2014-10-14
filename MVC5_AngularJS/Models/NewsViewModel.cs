using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Models.Base;

namespace MVC5_AngularJS.Models
{
    public class NewsViewModel : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}