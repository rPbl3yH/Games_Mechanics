using Atomic;
using AtomicHomework.Atomic.Enemy.Entity;
using Entities;

namespace AtomicProject.Entities.Components
{
    public interface IFindComponent
    {
        void Find(IEntity entity);
    }

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