using System.ComponentModel;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Toka.BaseServices.Common.Wrapper;
using Toka.BaseServices.Common.Wrapper.Impl;
using Toka.PhysicalPerson.Create;
using Toka.PhysicalPerson.Infrastructure.Containers.Scanners.Impl;
using Toka.WebApi.Infrastructure.Container.Scanner.Helper.Impl;
using Toka.WebApi.Infrastructure.Container.Scanner.Impl;

namespace TokaWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WindsorContainerWrapper.SetScanner(new TokaWebApiScanner());
            IWindsorContainerWrapper windsorContainerWrapp = new WindsorContainerWrapper();

//            var x = windsorContainerWrapp.Resolve<IPhysicalPCreateService>();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Services.Replace(
            typeof(IHttpControllerActivator),
                new CustomControllerActivator(windsorContainerWrapp));
        }
    }
}
