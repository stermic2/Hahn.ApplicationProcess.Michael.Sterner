using Autofac;
using AutoMapper;
using DynamicCQ;
using Hahn.ApplicationProcess.February2021.Domain.Models.Asset;
using MediatR;
using Module = Autofac.Module;

namespace Hahn.ApplicationProcess.February2021.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                builder.GenericallyRegisterAnEntityToDtos<DemoDbContext, AssetEntity, AssetDto>();
            });
            builder.Register(c =>
                {
                    var mapper = mapperCfg.CreateMapper();
                    return mapper;
                }).AsImplementedInterfaces().InstancePerLifetimeScope()
                .Named<IMapper>(nameof(Web));
            
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}