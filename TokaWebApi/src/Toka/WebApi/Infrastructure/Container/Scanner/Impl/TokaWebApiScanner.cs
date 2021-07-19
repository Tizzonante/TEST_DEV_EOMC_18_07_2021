using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Container.Scanners;
using Toka.BaseServices.Infrastructure.Container.Scanners.Impl;
using Toka.PhysicalPerson.Infrastructure.Containers.Scanners.Impl;
using Toka.WebApi.Infrastructure.Constant;

namespace Toka.WebApi.Infrastructure.Container.Scanner.Impl
{
    public class TokaWebApiScanner : ITokaContainerScanner
    {
        public void Register(IWindsorContainer container)
        {
            CommonScanner.Register(container, TokaWebApiInfrastructureConst.APPLICATION_ASSEMBLY_NAME);
            ControllersScanner.Register(container, TokaWebApiInfrastructureConst.APPLICATION_ASSEMBLY_NAME);

            CommonScanner.Register(container, new PhysicalPersonScanner());                      
        }
    }
}