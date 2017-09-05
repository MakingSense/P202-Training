using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class CreateUserHandler : RequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUsersService _usersService;

        public CreateUserHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Response Handle(CreateUserRequest request)
        {
            var response = CreateTypedResponse();
            _usersService.CreateUser(request.NewUser);
            return response;
        }
    }
}