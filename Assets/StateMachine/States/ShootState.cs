using System;
using AtomicProject.Hero;
using Declarative;

namespace StateMachine.States
{
    [Serializable]
    public class ShootState : CompositeState
    {
        public AnimationState AnimationState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState);
        }

        [Construct]
        public void ConstructStates(HeroVisual visual)
        {
            AnimationState.Construct(visual.Animator);
        }
    }
}