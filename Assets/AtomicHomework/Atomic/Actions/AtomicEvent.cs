using System;
using Declarative;
using Sirenix.OdinInspector;

namespace Atomic
{
    [Serializable]
    public sealed class AtomicEvent : IAtomicAction, IDisposable
    {
        private System.Action onEvent;

        public static AtomicEvent operator +(AtomicEvent it, System.Action action)
        {
            it.onEvent += action;
            return it;
        }
        
        public static AtomicEvent operator -(AtomicEvent it, System.Action action)
        {
            it.onEvent -= action;
            return it;
        }
        
        public void AddListener(System.Action action)
        {
            this.onEvent += action;
        }

        public void RemoveListener(System.Action action)
        {
            this.onEvent -= action;
        }

        [Button]
        public void Invoke()
        {
            this.onEvent?.Invoke();
        }

        public void Dispose()
        {
            DelegateUtils.Dispose(ref this.onEvent);
        }
    }

    [Serializable]
    public class AtomicEvent<T> : IAtomicAction<T>, IDisposable
    {
        private System.Action<T> onEvent;

        public static AtomicEvent<T> operator +(AtomicEvent<T> it, System.Action<T> action)
        {
            it.onEvent += action;
            return it;
        }
        
        public static AtomicEvent<T> operator -(AtomicEvent<T> it, System.Action<T> action)
        {
            it.onEvent -= action;
            return it;
        }
        
        public void AddListener(System.Action<T> action)
        {
            this.onEvent += action;
        }

        public void RemoveListener(System.Action<T> action)
        {
            this.onEvent -= action;
        }

        [Button]
        public void Invoke(T args)
        {
            this.onEvent?.Invoke(args);
        }

        public void Dispose()
        {
            DelegateUtils.Dispose(ref this.onEvent);
        }
    }
}