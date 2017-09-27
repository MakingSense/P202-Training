using P202.Training.Domain.Models;
using System.Collections.Generic;

namespace P202.Training.Domain
{
    public interface IRoleService
    {
        Role CreateRole(Role role);

        Role ReadRole(int id);

        IList<Role> ListRoles();

        Role UpdateRole(Role role);

        bool DeleteRole(int id);
    }
}
