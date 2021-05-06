using Autofac;
using AutoMapper;
using Entmaa_Web_Services.Persistence.MapperProfiles;

namespace Entmaa_Web_Services.Core.DIModules
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register AutoMapper Profiles
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<PostMappingProfile>();
                cfg.AddProfile<DonationMappingProfile>();
                cfg.AddProfile<ReportedItemMappingProfile>();
                cfg.AddProfile<AuctionMappingProfile>();
                cfg.AddProfile<DatasetMappingProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
                {
                    //This resolves a new context that can be used later.
                    var context = c.Resolve<IComponentContext>();
                    var config = context.Resolve<MapperConfiguration>();
                    return config.CreateMapper(context.Resolve);
                })
                .As<IMapper>().InstancePerLifetimeScope();
        }
    }
}