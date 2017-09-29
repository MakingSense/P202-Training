using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using P202.Training.Data.Entities;

namespace P202.Training.Data
{
    public class NHibernateSessionManager : INHibernateSessionManager
    {
        private ISessionFactory _sessionFactory;

        public NHibernateSessionManager()
        {
            InitializeSessionFactory();
        }
        
        private void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ToDoList>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
