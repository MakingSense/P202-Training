using System;

namespace P202.Training.Data.Entities
{
    public class Base
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Who created
        /// </summary>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// Who updated
        /// </summary>
        public virtual string UpdatedBy { get; set; }

        /// <summary>
        /// When created
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// When updated
        /// </summary>
        public virtual DateTime? UpdatedOn { get; set; }
    }
}
