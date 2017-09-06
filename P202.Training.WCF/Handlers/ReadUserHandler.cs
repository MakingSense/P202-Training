using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class ReadUserHandler : RequestHandler<ReadUserRequest, ReadUserResponse>
    {
        private readonly IUsersService _usersService;

        public ReadUserHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Response Handle(ReadUserRequest request)
        {
            var response = CreateTypedResponse();
            response.User = _usersService.ReadUser(request.User);
            return response;
        }
    }
}