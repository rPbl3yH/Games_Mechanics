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
        public AtomicVariable<float> Speed;
        public AtomicAction<Vector3> MoveRequest = new();
        public AtomicVariable<Vector3> Direction;

        public AtomicEvent OnMoveStarted;
        public AtomicEvent OnMoveFinished;

        [Construct]
        public void Construct()
        {
            MoveRequest.Use(direction =>
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
            }); 
        }
    }
}