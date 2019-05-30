using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application
{
    public interface IService<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
    }
}
