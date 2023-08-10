using System;
using AtomicProject.Atomic.Values;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class RunState : CompositeState
    {
        [HideInInspector] public MoveState MoveState;
        [HideInInspector] public RotateState RotateState;
                    
        [Construct]
        public void ConstructSelf()
        {
            SetStates(MoveState, RotateState);
        }
        
        [Construct]
        public void ConstructStates(HeroDocument heroDocument)
        {
            var moveSection = heroDocument.Core.MoveSection;
            MoveState.Construct(heroDocument.Transform, moveSection.Direction, moveSection.Speed);
            RotateState.Construct(heroDocument.Transform, 
                new AtomicValue<Quaternion>(() => Quaternion.LookRotation(heroDocument.Core.RotateSection.LookDirection.Value)));
        }
    }
}