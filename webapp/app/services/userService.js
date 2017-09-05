define('services/userService', [], function () {
    
    function CreateUser(value) {
        // TODO: refactor common headers and base url
        return $.ajax({
          type: 'POST',
          contentType: 'application/json',
          url:'http://localhost:10160/Service.svc/jsonp/post',
          data: '{"requests":[{"__type":"CreateUserRequest:#P202.Training.WCF.RequestsAndResponses","NewUser":' + value + '}]}'
        });
      }

      function ListUsers() {
        // TODO: refactor common headers and base url
        return $.ajax({
          type: 'POST',
          contentType: 'application/json',
          url:'http://localhost:10160/Service.svc/jsonp/post',
          data: '{"requests":[{"__type":"ListUsersRequest:#P202.Training.WCF.RequestsAndResponses"}]}'
        });
      }

      return {
        CreateUser: CreateUser,
        ListUsers: ListUsers
      };
    
    });