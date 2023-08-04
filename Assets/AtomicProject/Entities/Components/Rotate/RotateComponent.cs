using AtomicProject.Atomic.Actions;
using UnityEngine;

namespace AtomicProject.Entities.Components.Rotate
{
    public class RotateComponent : IRotateComponent
    {
        private readonly IAtomicAction<Vector3> _onRotate;
        
        public RotateComponent(IAtomicAction<Vector3> onRotate)
        {
            _onRotate = onRotate;
        }
        
        public void Rotate(Vector3 direction)
        {
            _onRotate?.Invoke(direction);
        }
    }
}