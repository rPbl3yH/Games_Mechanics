using System;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class RotateState : IState, IFixedUpdateListener
    {
        private IAtomicValue<Quaternion> _rotation;
        private Transform _transform;
        private bool _isEnabled;

        public void Construct(Transform transform, IAtomicValue<Quaternion> rotation)
        {
            _rotation = rotation;
            _transform = transform;
        }

        public void Enter()
        {
            _isEnabled = true;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            if (_isEnabled)
            {
                _transform.transform.rotation = _rotation.Value;
            }
        }

        public void Exit()
        {
            _isEnabled = false;
        }
    }
}