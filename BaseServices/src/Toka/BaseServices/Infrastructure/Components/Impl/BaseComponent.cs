using NLog;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Toka.BaseServices.Infrastructure.Components.Impl
{
    public class BaseComponent: IBaseComponent
    {
        protected bool _disposed;
        protected ILogger Log => LogManager.GetLogger(GetType().FullName);

        protected BaseComponent() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _disposed = true;
        }
    }
}
