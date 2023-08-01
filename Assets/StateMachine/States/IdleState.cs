using System;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine
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