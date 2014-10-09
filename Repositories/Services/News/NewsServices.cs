using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Services
{
   public  static class NewsServices
    {
       public static IEnumerable<News> GetRecentNewses(this GenericRepository<News> entity )
       {
           var result = entity.Get().Take(5).OrderByDescending(a => a.CreationDate);
           return result; 
       }
    }
}
