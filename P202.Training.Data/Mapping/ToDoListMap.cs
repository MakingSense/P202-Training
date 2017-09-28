using FluentNHibernate.Mapping;
using P202.Training.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Data.Mapping
{
    public class ToDoListMap : ClassMap<ToDoList>
    {

        public ToDoListMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            //Should be in BaseMap Class
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedBy);
            Map(x => x.UpdatedOn);

            

            Table("ToDoList");
        }
    }
}
