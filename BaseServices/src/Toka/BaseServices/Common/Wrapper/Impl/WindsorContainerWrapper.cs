using Toka.BaseServices.Infrastructure.Components;
using Castle.Windsor;
using Toka.BaseServices.Infrastructure.Container.Scanners.Impl;
using System;
using Toka.BaseServices.Infrastructure.Container.Scanners;

namespace Toka.BaseServices.Common.Wrapper.Impl
{
    public class WindsorContainerWrapper : IWindsorContainerWrapper, ISingleton
    {
        public static IWindsorContainer WindsorContainer
        {
            get
            {
                return GlobalContainer.GetContainer();
            }
        }

        public static void SetScanner(ITokaContainerScanner scanner)
        {
            GlobalContainer.Scanner = scanner;
        }

        public T Resolve<T>()
        {
            return GlobalContainer.GetContainer().Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return GlobalContainer.GetContainer().Resolve(type);
        }
    }
}
