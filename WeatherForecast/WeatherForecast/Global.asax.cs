using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using Autofac;
using WeatherForecast.Controllers;

namespace WeatherForecast
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();
            /*
            builder.Register(c => new Country())
            .As<ICountry>()
            .InstancePerApiControllerType(typeof(WeatherController));
            */
            /* builder.Register(o => new OpenWeatherMap())
             .As<IOpenWeatherMap>()
             .InstancePerApiControllerType(typeof(WeatherController));
             */


            builder.RegisterType<Country>().As<ICountry>().InstancePerRequest();
            builder.RegisterType<OpenWeatherMap>().As<IOpenWeatherMap>().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}
