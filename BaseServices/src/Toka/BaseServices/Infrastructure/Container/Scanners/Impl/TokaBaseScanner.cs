using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Constant;

namespace Toka.BaseServices.Infrastructure.Container.Scanners.Impl
{
    public class TokaBaseScanner : ITokaContainerScanner
    {
        public void Register(IWindsorContainer container)
        {
            CommonScanner.Register(container, BaseInfrastructureConst.APPLICATION_ASSEMBLY_NAME);
        }
    }
}
