using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void CreateRole(Role role);
        void DeleteRole(Role role);
        IList<Role> GetAllRoles();
    }
}