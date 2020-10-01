using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Repository
{
    public interface IMDBInterfaceRepository<TEntity> where TEntity : EntityBase
    {
        void Delete(Guid id);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
