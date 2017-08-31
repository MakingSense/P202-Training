using System;
using System.Reflection;
using Agatha.ServiceLayer;
using Autofac;
using Autofac.Integration.Wcf;
using P202.Training.Data;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using P202.Training.WCF.RequestsAndResponses;
using AutoMapper;
using P202.Training.Data.Entities;

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
            builder.RegisterType<UsersService>().As<IUsersService>();

            // Register Automap
            Mapper.Initialize(cfg => cfg.CreateMap<Data.Entities.User, Domain.Models.User>().ReverseMap());

            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;

            var agathaContainer = new Agatha.Autofac.Container(container);

            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(EchoRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(CreateUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(DeleteUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(UpdateUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(ReadUserRequest).Assembly, agathaContainer).Initialize();
        }
    }
}