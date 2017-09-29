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
    public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(INHibernateSessionManager sessionManager) : base(sessionManager)
        {
        }
    }
}
