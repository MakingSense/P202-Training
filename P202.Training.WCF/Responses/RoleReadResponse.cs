using Agatha.Common;
using P202.Training.Data.Entities;

namespace P202.Training.WCF.Responses
{
    public class RoleReadResponse : Response
    {
        public Role Data { get; set; }
    }
}