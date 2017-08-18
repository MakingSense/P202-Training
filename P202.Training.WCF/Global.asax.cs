using Agatha.ServiceLayer;
using Autofac;
using Autofac.Integration.Wcf;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;
using System;
using System.Reflection;

namespace P202.Training.WCF
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            // Register services
            builder.RegisterType<EchoService>().As<IEchoService>();

            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;

            var agathaContainer = new Agatha.Autofac.Container(container);

            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(EchoRequest).Assembly, agathaContainer).Initialize();

        }
    }
}