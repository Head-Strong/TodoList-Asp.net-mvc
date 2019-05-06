using Autofac;
using Autofac.Integration.Mvc;
using Sample.ToDoList.Repository;
using Sample.ToDoList.Service;
using System.Reflection;
using System.Web.Mvc;

namespace Sample.ToDoList.Infrastructure
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<ToDoRepository>().As<IToDoRepository>().InstancePerRequest();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ToDoService>().As<IToDoService>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}