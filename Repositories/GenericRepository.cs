using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DataContexts;
using Entities.Models.Base;
using Repositories.Services.EntityBaseServices;

namespace Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        internal DbSet<TEntity> _dbSet;
        public AplicationDbContext Context;

        public GenericRepository(AplicationDbContext context)
        {
            _dbSet = context.Set<TEntity>();
            Context = context;
        }
        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query.Where(a => a.Estado == EstadosRegistros.Registro.Activo)).ToList();
            }
            else
            {
                return query.Where(a => a.Estado == EstadosRegistros.Registro.Activo).ToList();
            }
        }

        public virtual void Insert(TEntity entity)
        {
            //entity.Estado = EstadosRegistros.Registro.Activo;
            //entity.CreationDate = DateTime.Now;
            //entity.UserCreated = Environment.UserName;
            entity.SetValue();

            _dbSet.Add(entity);

            Context.SaveChanges();

        }

        public virtual void Delete(int? id)
        {
            //entidad que vamos a eliminar
            TEntity entity = _dbSet.Find(id);

            //cambiamos el estado a inactivo
            entity.Estado = EstadosRegistros.Registro.Inactivo;
            //actualizamos con el nuevo estadp
            Update(entity);
            //guardamos
            Context.SaveChanges();

        }

        public virtual void Update(TEntity entity)
        {
            //entity.Estado = EstadosRegistros.Registro.Activo;
            //entity.CreationDate = DateTime.Now;
            //entity.UserCreated = Environment.UserName;
            entity.SetValue();

            _dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public virtual IQueryable<TEntity> GetAll(
           Expression<Func<TEntity, bool>> filter = null,
                                  string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.Where(a => a.Estado == EstadosRegistros.Registro.Activo);

        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            var result = query.Where(a => a.Estado == EstadosRegistros.Registro.Activo).ToList();
            return result;
            //throw new NotImplementedException();
        }



        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                string includeProperties = "",
                                                                int jtStartIndex = 0,
                                                                int jtPageSize = 0,
                                                                string jtSorting = null,
                                                                bool orderDescending = false)
        {
            IQueryable<TEntity> query = GetAll(filter, includeProperties);


            if (jtPageSize == 0)
                jtPageSize = 10;

            query.Where(a => a.Estado == EstadosRegistros.Registro.Activo)
                 .ToList()
                 .Take(jtPageSize);
                               
            return query.Skip(jtStartIndex).Take(jtPageSize);
            //throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int? id)
        {
            TEntity result = _dbSet.Find(id);

            return result;
            //throw new NotImplementedException();
        }
    }
}
