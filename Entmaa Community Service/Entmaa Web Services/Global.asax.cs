using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac.Integration.Mvc;
using Autofac;
using Entmaa_Web_Services.Core.DIModules;
using Autofac.Integration.WebApi;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.Persistence;

namespace Entmaa_Web_Services
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.AddProfile<MappingProfile>();
            //});

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .WithParameter(new TypedParameter(typeof(MainContext), new MainContext()));

            // Register your MVC controllers. (MvcApplication is the name of the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            
            //Register AutoMapper here using AutoFacModule class (Both methods works)
            //builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule<AutoFacModule>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
