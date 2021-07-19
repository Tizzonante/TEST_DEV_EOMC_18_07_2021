using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Helper;

namespace Toka.BaseServices.Infrastructure.Container.Scanners.Impl
{
    public static class SingletonScanner
    {
        /// <summary>
        /// Register all services that implements ISingleton interface
        /// </summary>
        /// <param name="container"></param>
        /// <param name="assemblyName"></param>
        public static void Register(IWindsorContainer container, string assemblyName)
        {
            var descriptor = Classes.FromAssemblyNamed(assemblyName);

            container.Register(descriptor.Where(type =>
            CommonValidationScanner.HasSingletonInterface(type))
            .WithServiceAllInterfaces()
            .LifestyleSingleton()
            );
        }
    }
}
