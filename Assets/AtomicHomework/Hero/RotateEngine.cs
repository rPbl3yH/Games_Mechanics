using Atomic;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class RotateEngine : IUpdateListener
    {
        private Transform _transform;
        private IAtomicValue<float> _speed;
        private IAtomicValue<Vector3> _targetPoint;

        private bool _isRotateRequired;
        
        public void Construct(Transform transform, IAtomicValue<float> speed, IAtomicValue<Vector3> targetPoint)
        {
            _transform = transform;
            _speed = speed;
            _targetPoint = targetPoint;
        }

        public void Rotate()
        {
            _isRotateRequired = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRotateRequired)
            {
                //Debug.Log("target point " + _targetPoint.Value);
                var direction = _targetPoint.Value - _transform.position;
                _transform.rotation = Quaternion.LookRotation(direction);
                _isRotateRequired = false;
            }
        }
    }
}