using Castle.Windsor;
using NLog;
using System;

namespace Toka.BaseServices.Infrastructure.Container.Scanners.Impl
{
    public static class CommonScanner
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Register(IWindsorContainer container, string assemblyName)
        {
            InterfacesScanner.Register(container, assemblyName);
            SingletonScanner.Register(container, assemblyName);
        }

        public static void Register(IWindsorContainer container, ITokaContainerScanner containerScanner)
        {
            Type type = containerScanner.GetType();

            Log.Info("Registry in Castle Windsor Container the services through scanner: {0}", type.FullName);
            containerScanner.Register(container);
        }
    }
}
