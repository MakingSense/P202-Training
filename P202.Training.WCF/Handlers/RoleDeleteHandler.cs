using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class RoleDeleteHandler : RequestHandler<RoleDeleteRequest, RoleDeleteResponse>
    {
        private readonly IRoleService _roleService;

        public RoleDeleteHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override Response Handle(RoleDeleteRequest request)
        {
            var response = CreateTypedResponse();
            response.Deleted = _roleService.DeleteRole(request.RoleId);
            return response;
        }
    }    
}