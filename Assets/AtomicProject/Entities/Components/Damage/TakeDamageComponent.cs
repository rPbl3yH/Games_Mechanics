using AtomicProject.Atomic.Actions;

namespace AtomicProject.Entities.Components.Damage
{
    class TakeDamageComponent : ITakeDamageComponent
    {
        private readonly IAtomicAction<int> _onTakeDamage;

        public TakeDamageComponent(IAtomicAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int value)
        {
            _onTakeDamage?.Invoke(value);    
        }
    }
}