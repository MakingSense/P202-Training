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
using System.Collections.Generic;

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
            builder.Register(c => new MapperConfiguration(cfg => cfg.CreateMap<Data.Entities.User, Domain.Models.User>().ReverseMap())).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;

            var agathaContainer = new Agatha.Autofac.Container(container);

            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(EchoRequest).Assembly, agathaContainer).Initialize();
            //Role
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleAddRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleReadRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleReadAllRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleUpdateRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleDeleteRequest).Assembly, agathaContainer).Initialize();
        }
    }
}