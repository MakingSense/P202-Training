using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class DeleteUserHandler : RequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUsersService usersService, IUserRepository userRepository)
        {
            _usersService = usersService;
            _userRepository = userRepository;
        }

        public override Response Handle(DeleteUserRequest request)
        {
            var response = CreateTypedResponse();
            _usersService.DeleteUser(request.User, _userRepository);
            return response;
        }
    }
}