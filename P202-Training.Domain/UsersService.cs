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

        public void CreateUser(User user)
        {
            if (user == null)
                return;
            var mapUser = _mapper.Map<Data.Entities.User>(user);
            _userRepository.CreateUser(mapUser);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IList<User> ListUsers()
        {
            var listUsers = _userRepository.GetAllUsers();
            var mapUser = _mapper.Map<IList<User>>(listUsers);
            return mapUser;
        }

        public User ReadUser(int id)
        {
            var listUsers = _userRepository.GetUser(id);
            var mapUserResp = _mapper.Map<User>(listUsers);
            return mapUserResp;
        }

        public User UpdateUser(User user)
        {
            if (user == null)
                return user;
            var mapUser = _mapper.Map<Data.Entities.User>(user);
            var respUpdateUser = _userRepository.UpdateUser(mapUser);
            var unmapUser = _mapper.Map<User>(respUpdateUser);
            return unmapUser;
        }
    }
}
