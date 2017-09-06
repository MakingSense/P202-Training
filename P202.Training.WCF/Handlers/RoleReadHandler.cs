using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class RoleReadHandler : RequestHandler<RoleReadRequest, RoleReadResponse>
    {
        private readonly IRoleService _roleService;

        public RoleReadHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public override Response Handle(RoleReadRequest request)
        {
            var response = CreateTypedResponse();
            response.Data = _roleService.ReadRole(request.RoleId);
            return response;
        }
    }
}