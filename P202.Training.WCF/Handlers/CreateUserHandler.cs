using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;

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