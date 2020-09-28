using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Repository
{
    public interface InterfaceUnitOfWork
    {
        IMDBInterfaceRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;
        void SaveChanges();
    }
}
