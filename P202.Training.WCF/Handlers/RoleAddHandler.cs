using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class RoleAddHandler : RequestHandler<RoleAddRequest, RoleAddResponse>
    {
        private readonly IRoleService _roleService;

        public RoleAddHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override Response Handle(RoleAddRequest request)
        {
            var response = CreateTypedResponse();
            _roleService.CreateRole(request.Role);
            return response;
        }
    }
}