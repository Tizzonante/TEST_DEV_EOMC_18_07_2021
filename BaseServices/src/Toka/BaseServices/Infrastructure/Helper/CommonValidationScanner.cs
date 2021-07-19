using AutoMapper;
using Castle.Windsor;
using System;
using Toka.BaseServices.Infrastructure.Components;

namespace Toka.BaseServices.Infrastructure.Helper
{
    public static class CommonValidationScanner
    {
        public static bool BaseTypeIsAdapter(Type type)
        {
            return type.BaseType.Equals(typeof(Profile));
        }

        public static bool HasSingletonInterface(Type type)
        {
            return type.GetInterface(typeof(ISingleton).Name) != null;
        }

        public static bool HasBeenRegistred(IWindsorContainer container, Type type)
        {
            return container.Kernel.HasComponent(type);
        }
    }
}
