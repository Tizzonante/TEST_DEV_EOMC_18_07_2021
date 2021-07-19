using System;

namespace Toka.BaseServices.Common.Wrapper
{
    public interface IWindsorContainerWrapper
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}
