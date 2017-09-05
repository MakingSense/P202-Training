using System.Collections.Generic;
using Agatha.Common;
using P202.Training.Data.Entities;

namespace P202.Training.WCF.Responses
{
    public class RoleReadAllResponse : Response
    {
        public IList<Role> Roles { get; set; }
    }
}