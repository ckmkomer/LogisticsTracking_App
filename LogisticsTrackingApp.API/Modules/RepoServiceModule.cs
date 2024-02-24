using Autofac;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Core.Services;
using LogisticsTrackingApp.Data.Context;
using LogisticsTrackingApp.Data.Repositories;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Mapping;
using LogisticsTrackingApp.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace LogisticsTrackingApp.API.Modules
{
	public class RepoServiceModule :Module
	{
		protected override void Load(ContainerBuilder builder)
		{

			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


			var apiAssembly =Assembly.GetExecutingAssembly();
			var dataAssembly = Assembly.GetAssembly(typeof(LogisticsDbContext));
			var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));


			builder.RegisterAssemblyTypes(apiAssembly, dataAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(apiAssembly, dataAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
		}
	}
}
