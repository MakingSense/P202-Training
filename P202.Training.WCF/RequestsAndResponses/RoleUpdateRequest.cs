using Agatha.Common;
using P202.Training.Domain.Models;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class RoleUpdateRequest : Request
    {
        public int Id { get; set; }
        public Role Role { get; set; }
    }
}