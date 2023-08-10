using AtomicProject.Atomic.Actions;
using Entities;

namespace AtomicProject.Entities.Components
{
    class FindComponent : IFindComponent
    {
        private readonly IAtomicAction<IEntity> _onFind;

        public FindComponent(IAtomicAction<IEntity> onFind)
        {
            _onFind = onFind;
        }
        
        public void Find(IEntity entity)
        {
            _onFind?.Invoke(entity);
        }
    }
}