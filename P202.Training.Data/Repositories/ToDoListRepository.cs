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
    public class ToDoListRepository : IToDoListRepository
    {

        private readonly INHibernateSessionManager _sessionManager;

        public ToDoListRepository(INHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDoList"></param>
        public void CreateToDoList(ToDoList toDoList)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(toDoList);
                transaction.Commit();
            }
        }

        public void DeleteToDoList(int id)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var toDoList = session.Load<ToDoList>(id);
                session.Delete(toDoList);
                transaction.Commit();
            }
        }

        public IList<ToDoList> GetAllToDoList()
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<ToDoList>();
                return criteria.List<ToDoList>();
            }
        }

        public ToDoList GetToDoList(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<ToDoList>().Add(Restrictions.Eq("Id", id));
                return criteria.UniqueResult<ToDoList>();
            }
        }

        public ToDoList UpdateToDoList(ToDoList toDoList)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(toDoList);
                transaction.Commit();
            }
            return toDoList;
        }
    }
}
