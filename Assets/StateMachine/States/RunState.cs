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
        [HideInInspector]
        public MoveState MoveState;
        
        [Construct]
        public void ConstructStates(HeroVisual heroVisual, HeroCore heroCore)
        {
            AnimationState.Construct(heroVisual.Animator);
            MoveState.Construct(heroCore.MoveSection);
        }
            
        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState, MoveState);
        }
    }
}