using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizBack.Entities;

namespace QuizBack.Services
{
    public interface ICrudService<TEntity> where TEntity : Entity
    {
        #region CREATE
        void Create(TEntity entity);
        #endregion

        #region READ
        TEntity GetById(object id);

        IEnumerable<TEntity> GetAll();
        #endregion

        #region UPDATE
        void Update(TEntity entityToUpdate);
        #endregion

        #region DELETE
        void Delete(object id);
        #endregion
    }
}
