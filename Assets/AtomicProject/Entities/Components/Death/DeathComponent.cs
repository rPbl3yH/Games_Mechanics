using Atomic;

namespace AtomicHomework.Entities.Components
{
    public class DeathComponent
    {
        public AtomicEvent OnDeath;

        public DeathComponent(AtomicEvent onDeath)
        {
            OnDeath = onDeath;
        }
    }
}