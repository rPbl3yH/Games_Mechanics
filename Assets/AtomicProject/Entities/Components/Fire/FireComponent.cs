using AtomicProject.Atomic.Actions;

namespace AtomicProject.Entities.Components.Fire
{
    public class FireComponent : IFireComponent
    {
        private readonly IAtomicAction _onFire;
        
        public FireComponent(IAtomicAction onFire)
        {
            _onFire = onFire;
        }

        public void Fire()
        {
            _onFire?.Invoke();    
        }
    }
}

