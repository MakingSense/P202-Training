using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(INHibernateSessionManager sessionManager) : base(sessionManager)
        {
        }
    }
}
