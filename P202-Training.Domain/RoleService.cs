using P202.Training.Data.Entities;
using P202.Training.Data.Repositories;
using System.Collections.Generic;
using P202.Training.Data;
using AutoMapper;

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
            var mapRole = _mapper.Map<Role>(role);
            _roleRepository.CreateRole(mapRole);
        }

        public bool DeleteRole(int roleId)
        {
            // TODO: Implemente DeleteRole method
            Role role = ReadRole(roleId);
            return true;
        }

        public IList<Role> ListRoles()
        {
            var listRoles = _roleRepository.GetAllRoles();
            var mapRole = _mapper.Map<IList<Role>>(listRoles);
            return mapRole;
        }

        public Role ReadRole(int id)
        {
            // TODO: implemente DeleteRole method
            Role role = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            return role;
        }

        public Role UpdateRole(int id, Role roleNew)
        {
            //TODO: Implement update Role method
            if (roleNew != null)
            {
                roleNew.Name = "Updated";
            }
            return roleNew;
        }
    }
}
