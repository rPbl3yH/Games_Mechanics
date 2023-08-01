using System;
using AtomicHomework.Hero;
using Declarative;

namespace StateMachine
{
    [Serializable]
    public class RunState : CompositeState
    {
        public AnimationState AnimationState;
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