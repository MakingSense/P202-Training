using NHibernate;
using NHibernate.Criterion;
using P202.Training.Data.Entities;
using System.Collections.Generic;

namespace P202.Training.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly INHibernateSessionManager _sessionManager;

        public UserRepository(INHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        /// <summary>
        /// Method to insert a User in DataBase
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(user);
                transaction.Commit();
            }
        }

        public void DeleteUser(int id)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var user = session.Load<User>(id);
                session.Delete(user);
                transaction.Commit();
            }
        }

        public IList<User> GetAllUsers()
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<User>();
                return criteria.List<User>();
            }
        }

        public User GetUser(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<User>().Add(Restrictions.Eq("Id", id));
                return criteria.UniqueResult<User>();
            }
        }

        public void UpdateUser(User user)
        {
            using (var session = _sessionManager.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(user);
                transaction.Commit();
            }
        }
    }
}
