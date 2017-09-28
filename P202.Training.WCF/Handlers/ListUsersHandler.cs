using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

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