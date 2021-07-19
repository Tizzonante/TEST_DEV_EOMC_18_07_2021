using System;
using Castle.MicroKernel.Releasers;
using Castle.Windsor;
using Toka.BaseServices.Common.Exceptions;

namespace Toka.BaseServices.Infrastructure.Container.Scanners.Impl
{
    static class GlobalContainer
    {
        public static ITokaContainerScanner Scanner { get; set; }

        private static IWindsorContainer container;
        private static object lockContainer = new object();


        public static IWindsorContainer GetContainer()
        {
            CreateGlobalContainer();
            return container;
        }

        private static void CreateGlobalContainer()
        {
            lock (lockContainer)
            {
                if (container == null)
                {
                    BuildContainer();
                }
            }
        }

        private static void BuildContainer()
        {
            try
            {
                container = new WindsorContainer();
                container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();
                Scanner.Register(container);
            }
            catch (Exception ex)
            {
                string msg = String.Format("Error while creating global windsor container. Exception: {0}. StackTrace:{1}", ex.Message, ex.StackTrace);
                throw new TokaBaseException(msg, ex);
            }
        }
    }
}
