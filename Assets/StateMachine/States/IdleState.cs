using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class IdleState : CompositeState
    {
        public AnimationState AnimationState;
        [HideInInspector]
        public RotateState RotateState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState, RotateState);            
        }

        [Construct]
        public void ConstructStates(HeroDocument heroDocument)
        {
            AnimationState.Construct(heroDocument.Visual.Animator);
            RotateState.Construct(heroDocument.Transform, heroDocument.Core.RotateSection.TargetPoint);
        }
    }
}