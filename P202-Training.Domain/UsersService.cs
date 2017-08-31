using System;
using System.Collections.Generic;
using AutoMapper;
using P202.Training.Data;
//using P202.Training.Data.Entities;
using P202.Training.Data.Repositories;
using P202.Training.Domain.Models;

namespace P202.Training.Domain
{
    public class UsersService : IUsersService
    {
        public void CreateUser(User users, IUserRepository userRepository)
        {
            if (users == null) return;
            var mapUser = Mapper.Map<Data.Entities.User>(users);
            userRepository.CreateUser(mapUser);
        }

        public void DeleteUser(int userId, IUserRepository userRepository)
        {
            // TODO
        }

        public IList<User> ListUsers(IUserRepository userRepository)
        {
            var listUsers= userRepository.GetAllUsers();           
            var mapUser = Mapper.Map<IList<Models.User>>(listUsers);
            return mapUser;
        }

        public User ReadUser(int userId, IUserRepository userRepository)
        {
            // TODO
            return new User()
            {
                Email = "demo@demo.com",
                Username = "DemoUser"
            };
        }

        public User UpdateUser(User users, IUserRepository userRepository)
        {
            // TODO
            if (users != null)
            {
                users.Username = "Updated";
            }
            return users;
        }
    }
}
