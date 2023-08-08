using System;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class MouseRotateState : IFixedUpdateListener
    {
        private IAtomicValue<Vector3> _targetPoint;
        private Transform _transform;

        public void Construct(Transform transform, IAtomicValue<Vector3> targetPoint)
        {
            _targetPoint = targetPoint;
            _transform = transform;
        }

        public void FixedUpdate(float deltaTime)
        {
            _transform.transform.rotation = Quaternion.LookRotation(_targetPoint.Value);
        }
    }
}