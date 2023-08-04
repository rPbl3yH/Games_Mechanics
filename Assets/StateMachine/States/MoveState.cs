using System;
using AtomicProject.Atomic.Values;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class MoveState : IState, IFixedUpdateListener
    {
        private Transform _transform;
        private IAtomicValue<Vector3> Direction;
        private IAtomicValue<float> Speed;

        private bool _isEnabled;
        
        public void Construct(Transform transform, IAtomicValue<Vector3> direction, IAtomicValue<float> speed)
        {
            _transform = transform;
            Direction = direction;
            Speed = speed;
        }
        
        public void Enter()
        {
            _isEnabled = true;
        }

        public void Exit()
        {
            _isEnabled = false;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            if (_isEnabled)
            {
                _transform.Translate(Direction.Value * (Speed.Value * deltaTime));
            }
        }
    }
}