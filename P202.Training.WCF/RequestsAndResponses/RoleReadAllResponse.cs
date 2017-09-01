using Agatha.Common;
using P202.Training.Data;
using P202.Training.Data.Entities;
using System.Collections.Generic;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class RoleReadAllResponse : Response
    {
        public IList<Role> Roles { get; set; }
    }
}