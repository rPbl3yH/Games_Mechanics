using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class MoveSection
    {
        [SerializeField] public AtomicVariable<float> Speed;
        public AtomicEvent<Vector3> OnMove = new();
        public AtomicVariable<Vector3> Direction;

        public AtomicEvent OnMoveStarted;
        public AtomicEvent OnMoveFinished;

        private Transform _transform;

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            _transform = heroDocument.Transform;
            
            OnMove += direction =>
            {
                if (Direction.Value == Vector3.zero && direction != Vector3.zero)
                {
                    OnMoveStarted?.Invoke();
                }
                else if (Direction.Value != Vector3.zero && direction == Vector3.zero)
                {
                    OnMoveFinished?.Invoke();
                }
            };
            
            heroDocument.onFixedUpdate += deltaTime =>
            {
                _transform.Translate(Direction.Value * (Speed.Value * deltaTime));   
            };
        }
    }
}