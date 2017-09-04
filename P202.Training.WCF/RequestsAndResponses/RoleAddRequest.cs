using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class RoleAddRequest : Request
    {
        public Role Role { get; set; } 
    }
}