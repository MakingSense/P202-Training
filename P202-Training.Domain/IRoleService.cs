using P202.Training.Data.Entities;
using System.Collections.Generic;

namespace P202.Training.Domain
{
    public interface IRoleService
    {
        void CreateRole(Role role);

        Role ReadRole(int id);

        IList<Role> ListRoles();

        Role UpdateRole(int id, Role role);

        bool DeleteRole(int id);
    }
}
