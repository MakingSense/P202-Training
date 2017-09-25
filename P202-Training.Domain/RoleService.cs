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

        public void CreateRole(Role role)
        {
            if (role == null) return;
            var mapRole = _mapper.Map<Data.Entities.Role>(role);
            mapRole.CreatedOn = DateTime.Now;
            _roleRepository.CreateRole(mapRole);
        }

        public bool DeleteRole(int roleId)
        {
            try
            {
                var role = ReadRole(roleId);
                var mapRole = _mapper.Map<Data.Entities.Role>(role);
                _roleRepository.DeleteRole(mapRole);
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
            var listRoles = _roleRepository.GetAllRoles();
            var mapRole = _mapper.Map<IList<Data.Entities.Role>, IList<Domain.Models.Role>>(listRoles);
            return mapRole;
        }

        public Role ReadRole(int id)
        {           
            var role = _roleRepository.GetRole(id);
            var mapRole = _mapper.Map<Data.Entities.Role, Domain.Models.Role>(role);
            return mapRole;
        }

        public Role UpdateRole(Role roleNew)
        {
            var mapRole = _mapper.Map<Data.Entities.Role>(roleNew);
            var role = _roleRepository.UpdateRole(mapRole);
            return roleNew;
        }
    }
}
