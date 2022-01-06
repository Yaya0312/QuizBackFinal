using QuizBack.Repositories;
using System;
using System.Collections.Generic;
using QuizBack.Entities;

namespace QuizBack.Services
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : Entity
    {
        private readonly ICrudRepository<TEntity> _repository;

        public CrudService(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #region CREATE
        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("The entity is null");
            }
            _repository.Create(entity);
        }
        #endregion

        #region READ
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }
        #endregion

        #region UPDATE
        public void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentNullException("The entity is null");
            }
            _repository.Update(entityToUpdate);
        }
        #endregion

        #region DELETE
        public void Delete(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("The entity is null");
            } 
            _repository.Delete(id);
        }
        #endregion

    }
}
