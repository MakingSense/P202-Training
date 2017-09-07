define('services/userService', ['services/requestHelper'], function (requestHelper) {
  function CreateUser(value) {
    var data = '{"requests":[{"__type":"CreateUserRequest:#P202.Training.WCF.RequestsAndResponses","NewUser":' + value + '}]}'
    return requestHelper.NewAjaxCall(data);
  }

  function ListUsers() {
    var data = '{"requests":[{"__type":"ListUsersRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
    return requestHelper.NewAjaxCall(data);
  }

  function GetUser() {
    var data = '{"requests":[{"__type":"ReadUserRequest:#P202.Training.WCF.RequestsAndResponses","Id":' + value + '}]}'
    return requestHelper.NewAjaxCall(data);
  }

  function UpdateUser() {
    var data = '{"requests":[{"__type":"UpdateUserRequest:#P202.Training.WCF.RequestsAndResponses","User":' + value + '}]}'
    return requestHelper.NewAjaxCall(data);
  }

  function DeleteUser() {
    var data = '{"requests":[{"__type":"DeleteUserRequest:#P202.Training.WCF.RequestsAndResponses","Id":' + value + '}]}'
    return requestHelper.NewAjaxCall(data);
  }

  return {
    CreateUser: CreateUser,
    ListUsers: ListUsers,
    GetUser: GetUser,
    UpdateUser: UpdateUser,
    DeleteUser: DeleteUser
  };

});
