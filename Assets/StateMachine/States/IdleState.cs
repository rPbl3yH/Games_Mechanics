using System;
using AtomicProject.Hero;
using Declarative;

namespace StateMachine.States
{
    [Serializable]
    public class IdleState : CompositeState
    {
        public AnimationState AnimationState;

        [Construct]
        public void ConstructStates(HeroVisual heroVisual, HeroCore heroCore)
        {
            AnimationState.Construct(heroVisual.Animator);
        }

        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState);            
        }
    }
}