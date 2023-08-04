using System;

namespace AtomicHomework.Entities.Components
{
    public interface IDeathComponent
    {
        event Action OnDeath;
    }
}