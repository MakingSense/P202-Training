using P202.Training.Data.Repositories;
using System.Collections.Generic;
using AutoMapper;
using System;
using P202.Training.Domain.Models;

namespace P202.Training.Domain
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public Role CreateRole(Role role)
        {
            if (role == null)
                return null;

            var mapRole = _mapper.Map<Data.Entities.Role>(role);
            return  _mapper.Map<Models.Role>(_roleRepository.Create(mapRole));
        }

        public bool DeleteRole(int roleId)
        {
            try
            {
                var role = ReadRole(roleId);
                var mapRole = _mapper.Map<Data.Entities.Role>(role);
                _roleRepository.Delete(mapRole);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IList<Role> ListRoles()
        {
            var listRoles = _roleRepository.FindAll();
            var mapRole = _mapper.Map<IList<Data.Entities.Role>, IList<Domain.Models.Role>>(listRoles);
            return mapRole;
        }

        public Role ReadRole(int id)
        {
            var role = _roleRepository.FindById(id);
            var mapRole = _mapper.Map<Data.Entities.Role, Domain.Models.Role>(role);
            return mapRole;
        }

        public Role UpdateRole(Role roleNew)
        {
            var mapRole = _mapper.Map<Data.Entities.Role>(roleNew);
            var role = _roleRepository.Update(mapRole);
            return roleNew;
        }
    }
}
