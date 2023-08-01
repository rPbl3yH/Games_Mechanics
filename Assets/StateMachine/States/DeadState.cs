using System;
using Atomic;
using AtomicHomework.Hero;
using Declarative;

namespace StateMachine
{
    [Serializable]
    public class DeadState : CompositeState
    {
        public AnimationState AnimationState;
        
        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState);
        }

        [Construct]
        public void ConstructStates(HeroVisual heroVisual)
        {
            AnimationState.Construct(heroVisual.Animator);
        }
    }
}