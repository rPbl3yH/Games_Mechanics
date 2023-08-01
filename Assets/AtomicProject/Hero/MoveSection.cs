using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class MoveSection
    {
        [SerializeField] public AtomicVariable<float> Speed;
        public AtomicEvent<Vector3> OnMove = new();

        public AtomicEvent OnMoveStarted;
        public AtomicEvent OnMoveFinished;

        private Transform _transform;
        private Vector3 _direction;
        private bool _isMoveRequired;

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            _transform = heroDocument.Transform;
            
            OnMove += direction =>
            {
                if (_direction == Vector3.zero && direction != Vector3.zero)
                {
                    OnMoveStarted?.Invoke();
                }
                else if (_direction != Vector3.zero && direction == Vector3.zero)
                {
                    OnMoveFinished?.Invoke();
                }
                
                _direction = direction;
                _isMoveRequired = true;
            };
            
            heroDocument.onFixedUpdate += deltaTime =>
            {
                if (_isMoveRequired)
                {
                    _transform.Translate(_direction * (Speed.Value * deltaTime));
                    _isMoveRequired = false;
                }   
            };
        }
    }
}