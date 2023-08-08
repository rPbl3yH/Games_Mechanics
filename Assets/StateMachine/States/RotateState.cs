using System;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class RotateState : IState, IFixedUpdateListener
    {
        private IAtomicValue<Vector3> _targetPoint;
        private Transform _transform;
        private bool _isEnabled;

        public void Construct(Transform transform, IAtomicValue<Vector3> targetPoint)
        {
            _targetPoint = targetPoint;
            _transform = transform;
        }

        public void Enter()
        {
            _isEnabled = true;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            _transform.transform.rotation = Quaternion.LookRotation(_targetPoint.Value);
        }

        public void Exit()
        {
            _isEnabled = false;
        }
    }
}