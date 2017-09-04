using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories
{
    public interface IRoleRepository
    {
        void CreateRole(Role role);
        void DeleteRole(Role role);
        IList<Role> GetAllRoles();
        Role UpdateRole(Role role);
        Role GetRole(int id);
    }
}