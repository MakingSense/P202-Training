define(['services/userService'], function (userService)
{
   var vm = 
    {
      getView: function () 
      {
        var view = require('./userDetail.html');
        return $.parseHTML(view)[0];
      },
      Title: "Peter",
      Id: ko.observable("1"),
      UserName: ko.observable("john.doe"),
      Email: ko.observable("john.doe@test.com"),
      FirstName: ko.observable("John"),
      LastName: ko.observable("Doe"),
      CreatedBy: ko.observable("Richard Prior"),
      CreatedOn: ko.observable("2017-09-26"),
      UpdatedBy: ko.observable( "Frank Columbo"),
      UpdatedOn: ko.observable("2017-09-28")  
    };
      
      
      vm.activate=function(){

        vm.Id = "1";
        vm.UserName = "john.doe";
        vm.Email = "john.doe@test.com";
        vm.FirstName = "John";
        vm.LastName = "Doe";
        vm.CreatedBy = "Richard Prior";
        vm.CreatedOn = "2017-09-26";
        vm.UpdatedBy = "Frank Columbo";
        vm.UpdatedOn = "2017-09-28";
  
      };
    

    return vm;
  });
  