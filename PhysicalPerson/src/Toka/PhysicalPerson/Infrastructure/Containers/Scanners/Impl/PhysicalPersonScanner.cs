using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Container.Scanners;
using Toka.BaseServices.Infrastructure.Container.Scanners.Impl;
using Toka.PhysicalPerson.Infrastructure.Constant;

namespace Toka.PhysicalPerson.Infrastructure.Containers.Scanners.Impl
{
    public class PhysicalPersonScanner : ITokaContainerScanner
    {
        public void Register(IWindsorContainer container)
        {
            CommonScanner.Register(container, PhysicalPersonInfrastructureConst.APPLICATION_ASSEMBLY_NAME);

            CommonScanner.Register(container, new TokaBaseScanner());
        }
    }
}
