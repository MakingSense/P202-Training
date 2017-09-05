using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User GetUser(User user);
        IList<User> GetAllUsers();
    }
}