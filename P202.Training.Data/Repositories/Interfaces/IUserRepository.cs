using System.Collections.Generic;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        IList<User> GetAllUsers();
    }
}