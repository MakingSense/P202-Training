using Agatha.Common;
using Agatha.ServiceLayer;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;
using P202.Training.WCF.Responses;

namespace P202.Training.WCF.Handlers
{
    public class DeleteUserHandler : RequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUsersService _usersService;

        public DeleteUserHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Response Handle(DeleteUserRequest request)
        {
            var response = CreateTypedResponse();
            _usersService.DeleteUser(request.User);
            return response;
        }
    }
}