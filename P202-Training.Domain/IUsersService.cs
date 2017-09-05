using System.Collections.Generic;
using P202.Training.Domain.Models;
using P202.Training.Data.Repositories;

namespace P202.Training.Domain
{
    public interface IUsersService
    {
        void CreateUser(User users);
        User ReadUser(User users);
        void UpdateUser(User users);
        void DeleteUser(User users);
        IList<User> ListUsers();
    }
}
