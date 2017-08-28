using NHibernate;

namespace P202.Training.Data
{
    public interface INHibernateSessionManager
    {
        ISession OpenSession();
    }
}