using NHibernate;
using NHibernate.Criterion;
using P202.Training.Data.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace P202.Training.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly INHibernateSessionManager _sessionManager;

        /// <summary>
        /// BaseRepository
        /// </summary>
        /// <param name="sessionManager"></param>
        public BaseRepository(INHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }


        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Create(T entity)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
            return entity;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
            return true;
        }

        /// <summary>
        /// DeleteByCriteria
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool DeleteByCriteria(Func<T,bool> criteria)
        {
            Expression<Func<T, bool>> expressionCriteria = mc => criteria(mc);

            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var deleteCriteria = session.CreateCriteria<T>().Add(Restrictions.Where<T>(expressionCriteria));
                session.Delete(deleteCriteria.UniqueResult<T>());
                transaction.Commit();
            }
            return true;
        }

        /// <summary>
        /// FindAllByCriteria
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> FindAllByCriteria(Func<T, bool> criteria)
        {
            Expression<Func<T, bool>> expressionCriteria = mc => criteria(mc);
            using (var session = _sessionManager.OpenSession())
            {
                var findCriteria = session.CreateCriteria<T>().Add(Restrictions.Where<T>(expressionCriteria)); 
                return findCriteria.List<T>();
            }
        }

        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> FindAll()
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<T>();
                return criteria.List<T>();
            }
        }

        /// <summary>
        /// FindById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T FindById(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id));
                return criteria.UniqueResult<T>();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Update(T entity)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
                return entity;
            }

        }
    }
}
