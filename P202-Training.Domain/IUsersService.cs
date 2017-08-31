using System.Collections.Generic;
using P202.Training.Domain.Models;
using P202.Training.Data.Repositories;

namespace P202.Training.Domain
{
    public interface IUsersService
    {
        void CreateUser(User users, IUserRepository userRepository);
        User ReadUser(int userId, IUserRepository userRepository);
        User UpdateUser(User users, IUserRepository userRepository);
        void DeleteUser(int userId, IUserRepository userRepository);
        IList<User> ListUsers(IUserRepository userRepository);
    }
}
