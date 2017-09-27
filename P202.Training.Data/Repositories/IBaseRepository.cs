using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;

namespace P202.Training.Data.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        bool DeleteByCriteria(Func<T,bool> criteria);
        T FindById(int id);
        IList<T> FindAll();
        IList<T> FindAllByCriteria(Func<T, bool> criteria);
    }
}
