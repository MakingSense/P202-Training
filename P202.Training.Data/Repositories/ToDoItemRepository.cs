using NHibernate;
using NHibernate.Criterion;
using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {


        private readonly INHibernateSessionManager _sessionManager;

        public ToDoItemRepository(INHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ToDoItem"></param>
        public void CreateToDoItem(ToDoItem toDoItem)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(toDoItem);
                transaction.Commit();
            }
        }

        public void DeleteToDoItem(int id)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var ToDoItem = session.Load<ToDoItem>(id);
                session.Delete(ToDoItem);
                transaction.Commit();
            }
        }

        public IList<ToDoItem> GetAllToDoItem()
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<ToDoItem>();
                return criteria.List<ToDoItem>();
            }
        }

        public ToDoItem GetToDoItem(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<ToDoItem>().Add(Restrictions.Eq("Id", id));
                return criteria.UniqueResult<ToDoItem>();
            }
        }

        public ToDoItem UpdateToDoItem(ToDoItem toDoItem)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(toDoItem);
                transaction.Commit();
            }
            return toDoItem;
        }
    }
}
