using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Context;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;
using ProjectIMDB.Mappers;

namespace ProjectIMDB.Repository
{
    public class IMDBRepository<TEntity> : IMDBInterfaceRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IMDBContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public IMDBRepository(IMDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(Guid id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
    }
}
