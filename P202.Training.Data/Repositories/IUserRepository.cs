using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(int id);
        User UpdateUser(User user);
        User GetUser(int id);
        IList<User> GetAllUsers();
    }
}