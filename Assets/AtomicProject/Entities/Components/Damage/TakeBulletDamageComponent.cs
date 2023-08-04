using AtomicProject.Atomic.Actions;

namespace AtomicProject.Entities.Components.Damage
{
    class TakeBulletDamageComponent : ITakeBulletDamageComponent
    {
        private readonly IAtomicAction<int> _onTakeDamage;

        public TakeBulletDamageComponent(IAtomicAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int value)
        {
            _onTakeDamage?.Invoke(value);    
        }
    }
}