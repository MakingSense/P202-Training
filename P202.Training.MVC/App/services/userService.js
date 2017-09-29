define(['services/requestHelper'], function (requestHelper)
{        
    var service = {};

    function CreateUser(value) {
      var data = '{"requests":[{"__type":"CreateUserRequest:#P202.Training.WCF.RequestsAndResponses","NewUser":' + value + '}]}'
      return requestHelper.NewAjaxCall(data);      
    }

    function ListUsers() {
      var data = '{"requests":[{"__type":"ListUsersRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
      return requestHelper.NewAjaxCall(data);
    }
          
      function GetUser(value) {
        var data = '{"requests":[{"__type":"ReadUserRequest:#P202.Training.WCF.RequestsAndResponses","Id":' + value + '}]}'
        return requestHelper.NewAjaxCall(data);
      }

      function UpdateUser(value) {        
        var data = '{"requests":[{"__type":"UpdateUserRequest:#P202.Training.WCF.RequestsAndResponses","User":' + value + '}]}'      
        return requestHelper.NewAjaxCall(data);
      }

      function DeleteUser(value) {
        var data = '{"requests":[{"__type":"DeleteUserRequest:#P202.Training.WCF.RequestsAndResponses","Id":' + value + '}]}'      
        return requestHelper.NewAjaxCall(data);
      }

      service.CreateUser = CreateUser;
      service.ListUsers = ListUsers;
      service.GetUser = GetUser;
      service.UpdateUser = UpdateUser;
      service.DeleteUser = DeleteUser;

      return service;
    
});