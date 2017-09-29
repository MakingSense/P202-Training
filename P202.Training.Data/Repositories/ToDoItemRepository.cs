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
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(INHibernateSessionManager sessionManager) : base(sessionManager)
        {
        }
    }
}
