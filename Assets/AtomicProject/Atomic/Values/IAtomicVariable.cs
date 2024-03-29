using System;

namespace AtomicProject.Atomic.Values
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        event Action<T> OnChanged;

        new T Value { get; set; }
    }
}