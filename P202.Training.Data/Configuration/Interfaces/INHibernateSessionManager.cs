using NHibernate;

namespace P202.Training.Data.Configuration.Interfaces
{
    public interface INHibernateSessionManager
    {
        ISession OpenSession();
    }
}