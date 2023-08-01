using System;

namespace Atomic
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        event Action<T> OnChanged;

        new T Value { get; set; }
    }
}