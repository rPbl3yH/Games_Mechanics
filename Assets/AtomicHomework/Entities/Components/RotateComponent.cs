using Atomic;
using UnityEngine;

namespace AtomicHomework.Entities.Components
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

    public interface IRotateComponent
    {
        void Rotate(Vector3 direction);
    }
}