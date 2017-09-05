using Agatha.Common;

namespace P202.Training.WCF.Requests
{
    public class RoleReadAllRequest : Request
    {
        /// <summary>
        /// Number of rows to show
        /// </summary>
        public int Limit { get; set; }
    }
}