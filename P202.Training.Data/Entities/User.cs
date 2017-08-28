namespace P202.Training.Data.Entities
{
    /// <summary>
    /// Unique property that identifies a certain user.        
    /// </summary>
    public class User : Base
    {
        /// <summary>
        /// First name of the person.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Last name, family name or surname of the person.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Email address of the person.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// UserName of the person.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Role of the person.
        /// </summary>
        public virtual Role UserRole { get; set; }
    }
}
