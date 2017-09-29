using FluentNHibernate.Mapping;
using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Mapping
{
    public class ToDoItemMap : ClassMap<ToDoItem>
    {
        public ToDoItemMap() {
            Id(x => x.Id);

            Map(x => x.Description);
            Map(x => x.Priority);

            //Should be in BaseMap Class
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedBy);
            Map(x => x.UpdatedOn);

            References(x => x.ToDoList).Column("ToDoListId");

            Table("ToDoItem");

        }
    }
}
