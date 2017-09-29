using System.Collections.Generic;
using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class ListUsersResponse : Response
    {
        public IList<User> UserList { get; set; }
    }
}