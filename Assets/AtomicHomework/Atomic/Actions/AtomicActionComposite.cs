using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Atomic
{
    [Serializable]
    public class AtomicActionComposite : IAtomicAction
    {
        private readonly List<IAtomicAction> actions = new();
        private readonly List<IAtomicAction> cache = new();
        
        public static AtomicActionComposite operator +(AtomicActionComposite it, IAtomicAction action)
        {
            it.actions.Add(action);
            return it;
        }

        public static AtomicActionComposite operator -(AtomicActionComposite it, IAtomicAction action)
        {
            it.actions.Remove(action);
            return it;
        }
        
        public void AddAction(IAtomicAction action)
        {
            this.actions.Add(action);
        }
        
        public void RemoveAction(IAtomicAction action)
        {
            this.actions.Remove(action);
        }

        [Button]
        public void Invoke()
        {
            this.cache.Clear();
            this.cache.AddRange(this.actions);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var action = this.cache[i];
                action.Invoke();
            }
        }
    }

    [Serializable]
    public class AtomicActionComposite<T> : IAtomicAction<T>
    {
        private readonly List<IAtomicAction<T>> actions = new();
        private readonly List<IAtomicAction<T>> cache = new();

        public static AtomicActionComposite<T> operator +(AtomicActionComposite<T> it, IAtomicAction<T> action)
        {
            it.actions.Add(action);
            return it;
        }

        public static AtomicActionComposite<T> operator -(AtomicActionComposite<T> it, IAtomicAction<T> action)
        {
            it.actions.Remove(action);
            return it;
        }
        
        public void AddAction(IAtomicAction<T> action)
        {
            this.actions.Add(action);
        }
        
        public void RemoveAction(IAtomicAction<T> action)
        {
            this.actions.Remove(action);
        }

        [Button]
        public void Invoke(T args)
        {
            this.cache.Clear();
            this.cache.AddRange(this.actions);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var action = this.cache[i];
                action.Invoke(args);
            }
        }
    }
}