using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application
{
    public interface IService<TEntity,TResponse> where TEntity : class
    {
        int Insert(TEntity entity);
        void Update(TEntity entity,int id);
        void Delete(TEntity entity);
        TResponse GetById(int id);
        IQueryable<TResponse> GetAll();
        void DeleteById(int id);
    }
}
