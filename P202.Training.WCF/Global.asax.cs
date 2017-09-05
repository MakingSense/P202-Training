using System;
using System.Reflection;
using Agatha.ServiceLayer;
using Autofac;
using Autofac.Integration.Wcf;
using P202.Training.Data.Repositories;
using AutoMapper;
using System.Web;
using P202.Training.Data.Configuration;
using P202.Training.Data.Configuration.Interfaces;
using P202.Training.Data.Repositories.Interfaces;
using P202.Training.Domain.Services;
using P202.Training.Domain.Services.Interfaces;
using P202.Training.WCF.Requests;

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

            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(EchoRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(CreateUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(DeleteUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(UpdateUserRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(ReadUserRequest).Assembly, agathaContainer).Initialize();
            
            //Role
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleAddRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleReadRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleReadAllRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleUpdateRequest).Assembly, agathaContainer).Initialize();
            new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), typeof(RoleDeleteRequest).Assembly, agathaContainer).Initialize();
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