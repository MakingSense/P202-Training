using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Domain.Services.Interfaces
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
