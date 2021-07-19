using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Toka.BaseServices.Common.Wrapper;

namespace Toka.WebApi.Infrastructure.Container.Scanner.Helper.Impl
{
    public class CustomControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainerWrapper containerWrapper;

        public CustomControllerActivator(IWindsorContainerWrapper containerWrapper)
        {
            this.containerWrapper = containerWrapper;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return (IHttpController)containerWrapper.Resolve(controllerType);
        }
    }
}