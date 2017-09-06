using System.Collections.Generic;
using P202.Training.Domain.Models;

namespace P202.Training.Domain.Services.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(User users);
        User ReadUser(int userId);
        User UpdateUser(User users);
        void DeleteUser(int userId);
        IList<User> ListUsers();
    }
}
