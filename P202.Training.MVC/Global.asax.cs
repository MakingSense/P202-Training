using Agatha.Common;
using Autofac;
using Autofac.Integration.Mvc;
using P202.Training.WCF.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P202.Training.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            //builder.RegisterType<EchoService>().As<IEchoService>();
            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            // Set the dependency resolver.
            var container = builder.Build();
            var agathaContainer = new Agatha.Autofac.Container(container);
            new ClientConfiguration(Assembly.Load("P202.Training.WCF.RequestAndResponses"), agathaContainer).Initialize();

        }
    }
}
