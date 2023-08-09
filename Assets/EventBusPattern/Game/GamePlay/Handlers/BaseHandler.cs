using System;
using Zenject;

namespace EventBusPattern
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        [Inject] protected EventBus EventBus;
        
        public void Initialize()
        {
            EventBus.Subscribe<T>(OnHandleEvent);
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<T>(OnHandleEvent);
        }

        protected abstract void OnHandleEvent(T evt);
    }
}