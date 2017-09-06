using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

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