using System;
using Atomic;

namespace AtomicHomework.Entities.Components
{
    public class DeathComponent : IDeathComponent
    {
        public event Action OnDeath
        {
            add => _onDeath.AddListener(value);
            remove => _onDeath.RemoveListener(value);
        }

        private readonly AtomicEvent _onDeath;

        public DeathComponent(AtomicEvent onDeath)
        {
            _onDeath = onDeath;
        }
    }
}