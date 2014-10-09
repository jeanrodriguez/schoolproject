using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.Base;

namespace Repositories.Services.EntityBaseServices
{
   public static class EntityBaseService
    {
       public static void SetValue<TEntity>(this TEntity entity) where TEntity : BaseEntity
       {
           if (entity.Id >0 )//update
           {
               entity.CreationDate = DateTime.Now;
               entity.UserCreated = Environment.UserName;
               entity.Estado = EstadosRegistros.Registro.Activo;
           }
           else
           {
               entity.CreationDate = DateTime.Now;
               entity.UserCreated = Environment.UserName;
               entity.Estado = EstadosRegistros.Registro.Activo;
           }
       }
    }
}
