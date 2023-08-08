using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class RunState : CompositeState
    {
        public AnimationState AnimationState;
        [HideInInspector] public MoveState MoveState;
        [HideInInspector] public RotateState RotateState;
                    
        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState, MoveState, RotateState);
        }
        
        [Construct]
        public void ConstructStates(HeroVisual heroVisual, HeroDocument heroDocument)
        {
            AnimationState.Construct(heroVisual.Animator);
            
            var moveSection = heroDocument.Core.MoveSection;
            MoveState.Construct(heroDocument.Transform, moveSection.Direction, moveSection.Speed);
            RotateState.Construct(heroDocument.Transform, heroDocument.Core.RotateSection.TargetPoint);
        }
    }
}