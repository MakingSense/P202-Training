using Agatha.Common;
using P202.Training.Data.Entities;

namespace P202.Training.WCF.Requests
{
    public class RoleAddRequest : Request
    {
        public Role Role { get; set; } 
    }
}