using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

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
            response.RoleCreated = _roleService.CreateRole(request.Role);
            return response;
        }
    }
}