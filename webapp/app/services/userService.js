define('services/userService', [], function () {
    function newAjaxCall(dataService, successCallback, errorCallback) {
      return $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url:'http://localhost:10160/Service.svc/jsonp/post',
        data: dataService
      });
    } 

    function CreateUser(value) {
      var data = '{"requests":[{"__type":"CreateUserRequest:#P202.Training.WCF.RequestsAndResponses","NewUser":' + value + '}]}'
      return newAjaxCall(data);      
    }

    function ListUsers() {
      var data = '{"requests":[{"__type":"ListUsersRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
      return newAjaxCall(data);
    }
          
      function GetUser() {
        var data = '{"requests":[{"__type":"ReadUserRequest:#P202.Training.WCF.RequestsAndResponses","User":' + value + '}]}'
        return newAjaxCall(data);
      }

      function UpdateUser() {        
        var data = '{"requests":[{"__type":"UpdateUserRequest:#P202.Training.WCF.RequestsAndResponses","User":' + value + '}]}'      
        return newAjaxCall(data);
      }

      function DeleteUser() {
        var data = '{"requests":[{"__type":"DeleteUserRequest:#P202.Training.WCF.RequestsAndResponses","User":' + value + '}]}'      
        return newAjaxCall(data);
      }

      return {
        CreateUser: CreateUser,
        ListUsers: ListUsers,
        GetUser: GetUser,
        UpdateUser: UpdateUser,
        DeleteUser: DeleteUser
      };
    
});