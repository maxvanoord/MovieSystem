using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Context;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Repository
{
    public class UnitOfWork : InterfaceUnitOfWork
    {

        private readonly IMDBContext _context;

        public UnitOfWork(IMDBContext context)
        {
            _context = context;
        }

        public IMDBInterfaceRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            return new IMDBRepository<TEntity>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
