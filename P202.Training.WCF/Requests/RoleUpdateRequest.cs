using Agatha.Common;
using P202.Training.Data.Entities;

namespace P202.Training.WCF.Requests
{
    public class RoleUpdateRequest : Request
    {
        public int Id { get; set; }
        public Role Role { get; set; }
    }
}