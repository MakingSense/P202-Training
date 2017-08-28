using FluentNHibernate.Mapping;
using P202.Training.Data.Entities;

namespace P202.Training.Data.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedBy);
            Map(x => x.UpdatedOn);

            Table("Role");
        }
    }
}
