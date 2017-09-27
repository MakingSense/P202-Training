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

        public User CreateUser(User user)
        {
            if (user == null)
                return null;

            var mapUser = _mapper.Map<Data.Entities.User>(user);
            return _mapper.Map<Models.User>(_userRepository.Create(mapUser));
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteByCriteria(x => x.Id == id);
        }

        public IList<User> ListUsers()
        {
            var listUsers = _userRepository.FindAll();
            var mapUser = _mapper.Map<IList<User>>(listUsers);
            return mapUser;
        }

        public User ReadUser(int id)
        {
            var listUsers = _userRepository.FindById(id);
            var mapUserResp = _mapper.Map<User>(listUsers);
            return mapUserResp;
        }

        public User UpdateUser(User user)
        {
            if (user != null && user.Id > 0)
            {
                var entityUser = _userRepository.FindById(user.Id);
                if (entityUser != null)
                {
                    entityUser = MapToUserEntityFromUserModelForUpdate(user, entityUser);
                    user = _mapper.Map<Domain.Models.User>(_userRepository.Update(entityUser));
                }
            }
            return user;
        }

        private Data.Entities.User MapToUserEntityFromUserModelForUpdate(Domain.Models.User sourceUserModel, Data.Entities.User targetUserEntity)
        {
            targetUserEntity = _mapper.Map<Domain.Models.User, Data.Entities.User>(sourceUserModel, targetUserEntity,
            
                            opt =>
                                opt.BeforeMap((src, dest)
                                =>
                                {
                                    src.CreatedBy = dest.CreatedBy;
                                    src.CreatedOn = dest.CreatedOn;
                                   
                                    if (src.UserRole == null && dest.UserRole != null)
                                    {
                                        src.UserRole = _mapper.Map<Role>(dest.UserRole);
                                    }

                                })
                            );
                            
            return targetUserEntity;
        }


    }
}
