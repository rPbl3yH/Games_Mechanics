using System;
using AtomicProject.Hero;
using Declarative;

namespace StateMachine.States
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