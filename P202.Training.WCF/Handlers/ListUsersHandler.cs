using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class ListUsersHandler : RequestHandler<ListUsersRequest, ListUsersResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUserRepository _userRepository;

        public ListUsersHandler(IUsersService usersService, IUserRepository userRepository)
        {
            _usersService = usersService;
            _userRepository = userRepository;
        }

        public override Response Handle(ListUsersRequest request)
        {
            var response = CreateTypedResponse();
            response.UserList = _usersService.ListUsers(_userRepository);

            return response;
        }
    }
}