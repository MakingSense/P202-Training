using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(INHibernateSessionManager sessionManager) : base(sessionManager)
        {
        }
    }
}
