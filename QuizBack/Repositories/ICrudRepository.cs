using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QuizBack.Entities;

namespace QuizBack.Repositories
{
    public interface ICrudRepository<TEntity> where TEntity : Entity
    {
        #region CREATE
        /// <summary>
        /// Insert the new entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        void Create(TEntity entityToCreate);
        #endregion

        #region READ
        /// <summary>
        /// Find an entity with the given primary key values.
        /// </summary>
        /// <param name="keyValues">The values of the primary key.</param>
        /// <returns>The found entity or null.</returns>
        TEntity GetById(params object[] keyValues);
        
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>The all dataset.</returns>
        IEnumerable<TEntity> GetAll();

        #endregion

        #region UPDATE
        /// <summary>
        /// Update the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);
        #endregion

        #region DELETE
        /// <summary>
        /// Delete the entity by the specified primary key.
        /// </summary>
        /// <param name="id">The primary key of entity.</param>
        void Delete(object id);
        #endregion
    }
}
