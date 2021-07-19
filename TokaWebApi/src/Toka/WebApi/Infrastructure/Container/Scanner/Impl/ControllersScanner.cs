using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Toka.WebApi.Infrastructure.Container.Scanner.Impl
{
    public class ControllersScanner
    {
        public static void Register(IWindsorContainer container, string asseblyName)
        {
            var assemblyDescriptor = Classes.FromAssemblyNamed(asseblyName);

            container.Register(assemblyDescriptor
            .Pick().If(t => t.Name.EndsWith("Controller"))
            .Configure(configurer => configurer.Named(configurer.Implementation.Name))
            .LifestylePerWebRequest());
        }
    }
}