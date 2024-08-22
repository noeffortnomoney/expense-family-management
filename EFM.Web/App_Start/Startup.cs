using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using EFM.Repository.Infrastructure;
using EFM.Repository.Repositories;
using EFM.Repository;
using EFM.Service;
using EFM.Web.Mappings;

namespace EFM.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Đăng ký MVC controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Đăng ký Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Đăng ký AutoMapper
            builder.RegisterInstance(AutoMapperConfig.Mapper).As<IMapper>().SingleInstance();

            // Đăng ký các dịch vụ và repository
            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            /*builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();*/

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<EFMDbContext>().AsSelf().InstancePerRequest();

            var container = builder.Build();

            // Đặt Autofac DependencyResolver cho MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Đặt Autofac DependencyResolver cho Web API
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
