using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class UpdateUserHandler : RequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUsersService usersService, IUserRepository userRepository)
        {
            _usersService = usersService;
            _userRepository = userRepository;
        }

        public UpdateUserHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Response Handle(UpdateUserRequest request)
        {
            var response = CreateTypedResponse();
            response.User = _usersService.UpdateUser(request.User, _userRepository);
            return response;
        }
    }
}