using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Helper;

namespace Toka.BaseServices.Infrastructure.Container.Scanners.Impl
{
    public static class InterfacesScanner
    {
        public static void Register(IWindsorContainer container, string asseblyName)
        {
            var assemblyDescriptor = Classes.FromAssemblyNamed(asseblyName);

            container.Register(assemblyDescriptor.Where(type =>
            !CommonValidationScanner.BaseTypeIsAdapter(type)
            && !CommonValidationScanner.HasSingletonInterface(type)
            && !CommonValidationScanner.HasBeenRegistred(container, type))
            .WithServiceAllInterfaces()
            .LifestyleTransient());
        }
    }
}
