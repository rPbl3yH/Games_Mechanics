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

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
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
                
                Direction.Value = direction;
            };
        }
    }
}