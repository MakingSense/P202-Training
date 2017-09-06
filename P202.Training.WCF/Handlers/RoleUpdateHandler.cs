using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class RoleUpdateHandler : RequestHandler<RoleUpdateRequest, RoleUpdateResponse>
    {
        private readonly IRoleService _roleService;

        public RoleUpdateHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override Response Handle(RoleUpdateRequest request)
        {
            var response = CreateTypedResponse();
            response.RoleUpdated = _roleService.UpdateRole(request.Id, request.Role);
            return response;
        }
    }
}