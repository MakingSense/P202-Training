using Agatha.Common;
using P202.Training.Data.Entities;

namespace P202.Training.WCF.Responses
{
    public class RoleUpdateResponse : Response
    {
        public Role RoleUpdated { get; set; }
    }
}