using System.Collections.Generic;
using P202.Training.Domain.Models;

namespace P202.Training.Domain
{
    public interface IUsersService
    {
        User CreateUser(User users);
        User ReadUser(int id);
        User UpdateUser(User users);
        void DeleteUser(int id);
        IList<User> ListUsers();
    }
}
