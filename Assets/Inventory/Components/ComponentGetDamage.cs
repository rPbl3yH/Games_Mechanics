using AtomicProject.Atomic.Values;

namespace Inventory.Player
{
    public class ComponentGetDamage : IComponent_GetDamage
    {
        private readonly AtomicVariable<float> _damage;

        public ComponentGetDamage(AtomicVariable<float> damage)
        {
            _damage = damage;
        }

        public AtomicVariable<float> GetDamage()
        {
            return _damage;
        }
    }
}