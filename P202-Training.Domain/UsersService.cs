using System.Collections.Generic;
using AutoMapper;
using P202.Training.Data.Repositories;
using P202.Training.Domain.Models;

namespace P202.Training.Domain
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateUser(User users)
        {
            if (users == null) return;
            var mapUser = _mapper.Map<Data.Entities.User>(users);
            _userRepository.CreateUser(mapUser);
        }

        public void DeleteUser(int userId)
        {
            // TODO: Implement delete User method
        }

        public IList<User> ListUsers()
        {
            var listUsers= _userRepository.GetAllUsers();           
            var mapUser = _mapper.Map<IList<User>>(listUsers);
            return mapUser;
        }

        public User ReadUser(int userId)
        {
            // TODO: Implement Read User method
            return new User()
            {
                Email = "demo@demo.com",
                Username = "DemoUser"
            };
        }

        public User UpdateUser(User users)
        {
            // TODO: Implement update User method
            if (users != null)
            {
                users.Username = "Updated";
            }
            return users;
        }
    }
}
