using Agatha.Common;
using P202.Training.Data;

namespace P202.Training.WCF.RequestsAndResponses
{
    public class RoleReadRequest : Request
    {
        public int RoleId { get; set; }
    }    
}