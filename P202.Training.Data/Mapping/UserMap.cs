using FluentNHibernate.Mapping;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.UserName);
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedBy);
            Map(x => x.UpdatedOn);

            References(x => x.UserRole).Column("RoleId").LazyLoad(Laziness.False);

            Table("[dbo].[User]");
        }
    }
}
