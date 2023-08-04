using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Atomic.Custom
{
    public class FollowMechanics : IFixedUpdateListener
    {
        public AtomicEvent<Transform> OnTargetReach = new();
        public AtomicEvent<Transform> OnTargetLose = new();
        private IAtomicValue<bool> _isMoveRequired;
        private Transform _transform;
        private IAtomicValue<Transform> _target;
        private IAtomicValue<float> _speed;
        private IAtomicValue<float> _minDistance;

        private bool _isCanMove;

        public void Construct(IAtomicValue<bool> isMoveRequired, Transform transform, IAtomicValue<Transform> target,
            IAtomicValue<float> speed, IAtomicValue<float> minDistance)
        {
            _isMoveRequired = isMoveRequired;
            _transform = transform;
            _target = target;
            _speed = speed;
            _minDistance = minDistance;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            if (_isMoveRequired.Value)
            {
                _transform.LookAt(_target.Value);
                
                if (_isCanMove)
                {
                    _transform.Translate(Vector3.forward * (_speed.Value * deltaTime));
                }

                var distance = Vector3.Distance(_target.Value.position, _transform.position);

                if (distance <= _minDistance.Value)
                {
                    if (_isCanMove)
                    {
                        OnTargetReach?.Invoke(_target.Value);
                    }

                    _isCanMove = false;
                }
                else
                {
                    if (!_isCanMove)
                    {
                        OnTargetLose?.Invoke(_target.Value);
                    }

                    _isCanMove = true;
                }
            }
        }
    }
}