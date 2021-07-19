using Castle.Windsor;

namespace Toka.BaseServices.Infrastructure.Container.Scanners
{
    public interface ITokaContainerScanner
    {
        void Register(IWindsorContainer container);
    }
}
