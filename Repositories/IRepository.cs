using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Delete(int? id);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(int? id);
       
    }
}
