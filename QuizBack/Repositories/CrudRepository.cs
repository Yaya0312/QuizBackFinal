using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using QuizBack.Entities;

namespace QuizBack.Repositories
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public CrudRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region CREATE
        public virtual void Create(TEntity entityToCreate)
        {
            _dbContext.Add(entityToCreate);
            _dbContext.SaveChanges();
        }

        #endregion

        #region READ
        public virtual TEntity GetById(params object[] keyValues) => _dbSet.Find(keyValues);

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();
        
        #endregion

        #region UPDATE
        public async virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region DELETE
        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);

            if (entityToDelete != null)
            {
                _dbContext.Remove(entityToDelete);
            }
        }
        #endregion
        
        private bool Exists(Guid id)
        {
            return _dbContext.Questions.Any(e => e.Id == id);
        }
        
    }
}
