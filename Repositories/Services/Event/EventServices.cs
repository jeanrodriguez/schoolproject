using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataContexts;
using Entities.Models.Base;

namespace Repositories.Services.Event
{
    public static class EventServices 
    {
        //internal DbSet<Entities.Models.Event> _dbSet;
        //public AplicationDbContext Context;

        //public EventServices(AplicationDbContext context)
        //{
        //    _dbSet = context.Set<Entities.Models.Event>();
        //    Context = context;
        //}
        public static IEnumerable<Entities.Models.Event> GetRecentEvent(this GenericRepository<Entities.Models.Event> entity)
        {
            //var result = _dbSet.ToList().Where(a=>a.EventStartDate >= DateTime.Now).Take(4);
            var result = entity.Get().OrderByDescending(a=>a.EventStartDate).Take(4);
            return result;
        }
    }
}
