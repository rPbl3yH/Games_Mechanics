using System;

namespace AtomicProject.Entities.Components.Death
{
    public interface IDeathComponent
    {
        event Action OnDeath;
    }
}