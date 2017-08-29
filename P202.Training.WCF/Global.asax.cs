using Agatha.ServiceLayer;
using Autofac;
using Autofac.Integration.Wcf;
using P202.Training.Data;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;
using System;
using System.Reflection;
using System.Web;

namespace P202.Training.WCF
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            // Initialize NHibernate
            var sessionManager = new NHibernateSessionManager();
            builder.RegisterInstance<INHibernateSessionManager>(sessionManager).SingleInstance();

            // Register repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();

            // Register services
            builder.RegisterType<EchoService>().As<IEchoService>();

            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;

            var agathaContainer = new Agatha.Autofac.Container(container);

            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(EchoRequest).Assembly, agathaContainer).Initialize();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}