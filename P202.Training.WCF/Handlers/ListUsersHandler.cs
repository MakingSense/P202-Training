using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class ListUsersHandler : RequestHandler<ListUsersRequest, ListUsersResponse>
    {
        private readonly IUsersService _usersService;

        public ListUsersHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Response Handle(ListUsersRequest request)
        {
            var response = CreateTypedResponse();
            response.UserList = _usersService.ListUsers();

            return response;
        }
    }
}