using AtomicProject.Atomic.Actions;
using UnityEngine;

namespace AtomicProject.Entities.Components.Move
{
    public class MoveComponent : IMoveComponent
    {
        private readonly IAtomicAction<Vector3> _onMove;
        
        public MoveComponent(IAtomicAction<Vector3> onMove)
        {
            _onMove = onMove;
        }

        public void Move(Vector3 direction)
        {
            _onMove?.Invoke(direction);
        }
    }
}