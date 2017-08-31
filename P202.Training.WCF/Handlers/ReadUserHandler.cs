using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

namespace P202.Training.WCF.Handlers
{
    public class ReadUserHandler : RequestHandler<ReadUserRequest, ReadUserResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUserRepository _userRepository;

        public ReadUserHandler(IUsersService usersService, IUserRepository userRepository)
        {
            _usersService = usersService;
            _userRepository = userRepository;
        }

        public override Response Handle(ReadUserRequest request)
        {
            var response = CreateTypedResponse();
            //response.User = _usersService.ReadUser(request.User);
            return response;
        }
    }
}